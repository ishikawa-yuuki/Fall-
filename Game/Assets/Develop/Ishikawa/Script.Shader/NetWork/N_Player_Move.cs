using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class N_Player_Move : MonoBehaviour
{
    //十字キーとマウスで操作(矢印キー＝前後左右移動，マウス左右＝回転)

    public GameObject UI;
    //オンライン化に必要なコンポーネントを設定
    public PhotonView myPV;
    public PhotonTransformView myPTV;
    public float moveSpeed = 10.0F;       //歩行速度
    public float jumpSpeed = 0.8F;      //ジャンプ力

    private Camera mainCam;
    private Animator anim;
    private Vector3 velocity;
    private bool isGround = false;
    private bool pose = false;
    private Rigidbody rd;
    private float h, v;
    private float d = 0.4f;
    //　Playerレイヤー以外のレイヤーマスク
    int layerMask;

    //　段差を昇る為のレイを飛ばす位置
    [SerializeField]
    private Transform stepRay = null;

    //SE
    AudioSource audioSource;
    [SerializeField]
    private AudioClip sound_walk = null;
    [SerializeField]
    private AudioClip sound_jump = null;
    
    void Start()
    {
        
        if (myPV.IsMine&& PhotonNetwork.IsConnected)    //自キャラであれば実行
        {
            //MainCameraのtargetにこのゲームオブジェクトを設定
            mainCam = Camera.main;
            mainCam.GetComponent<N_Player_Camera>().target = this.gameObject.transform;
            UI.GetComponent<UIController_World>().SetState(true);
        }
        audioSource = GetComponent<AudioSource>();
        rd = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        layerMask = ~(1 << LayerMask.NameToLayer("Player"));
        if (SceneManager.GetActiveScene().name == "result")
        {
            anim.SetTrigger("Result");
        }
        
    }//Start()

    // Update is called once per frame
    void Update()
    {
        if (!myPV.IsMine || pose || !PhotonNetwork.IsConnected)//ネット上の操作キャラであるかの判定,カウント中、止めるため用
        {
            return;
        }
            //　確認の為レイを視覚的に見えるようにする
            Debug.DrawLine(stepRay.position + Vector3.up * 0.1f, stepRay.position + Vector3.down * d, Color.red);
        if (isGround)
        {
            velocity = Vector3.zero;

            h = Input.GetAxis("Horizontal");    //左右矢印キーの値(-1.0~1.0)
            v = Input.GetAxis("Vertical");      //上下矢印キーの値(-1.0~1.0)

            // カメラの方向から、X-Z平面の単位ベクトルを取得
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            // 方向キーの入力値とカメラの向きから、移動方向を決定
            Vector3 moveForward = cameraForward * v + Camera.main.transform.right * h;

            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            velocity = moveForward * moveSpeed;
            if (velocity == Vector3.zero)
            {
                anim.SetBool("isWalk", false);
            }
            else
            {
                anim.SetBool("isWalk", true);
            }
            if (Input.GetButtonDown("Jump")) //　ジャンプ
            {
                //　ジャンプしたら接地していない状態にする
                isGround = false;
                velocity *= 0.6f;
                velocity.y += jumpSpeed;
                anim.SetTrigger("Jump");
                audioSource.PlayOneShot(sound_jump);
            }

            // キャラクターの向きを進行方向に
            if (moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveForward);
            }




        }//isGround
        else
        {
            velocity.y -= 0.02f;
        }
    }
    void FixedUpdate()
    {
        
          rd.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
      
    }
    private void OnCollisionEnter(Collision collision)
    {

        //　地面に着地したかどうかの判定
        if (Physics.CheckSphere(stepRay.position, d, layerMask))
        {
            //Debug.Log("on");
            isGround = true;
            velocity.y = 0f;
        }

    }

    private void OnCollisionExit(Collision collision)
    {

        //　地面から降りた時の処理
        //　Fieldレイヤーのゲームオブジェクトから離れた時
        if (1 << collision.gameObject.layer != layerMask)
        {

            //　下向きにレイヤーを飛ばしFieldレイヤーと接触しなければ地面から離れたと判定する
            if (!Physics.Linecast(stepRay.position + Vector3.up * 0.1f, stepRay.position + Vector3.down * d, layerMask))
            {
                //Debug.Log("off");
                isGround = false;
            }
        }
    }
    public void SetPose(bool p)
    {
        pose = p;
    }

    public void PlayFootstepSE()
    {
        audioSource.PlayOneShot(sound_walk);
    }
}

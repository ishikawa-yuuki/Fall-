using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    //十字キーとマウスで操作(矢印キー＝前後左右移動，マウス左右＝回転)

    private float moveSpeed = 10.0f;              // 移動速度
    //private float moveForceMultiplier=50.0f;    // 移動速度の入力に対する追従度
   
    
    public float jumpSpeed = 0.8F;      //ジャンプ力

    private Animator anim;
    private Vector3 moveVector;
    private bool isGround = false;
    private Rigidbody _rb;
    private float _horizontalInput, _verticalInput;
    private float d = 0.4f;
    //　Playerレイヤー以外のレイヤーマスク
    int layerMask;
    [SerializeField]
    private bool state = false;
    //　段差を昇る為のレイを飛ばす位置
    [SerializeField]
    private Transform stepRay =null;
    //　レイを飛ばす距離
    //[SerializeField]
    //private float stepDistance = 2.5f;
    ////　昇れる段差
    //[SerializeField]
    //private float stepOffset = 0.3f;
    ////　昇れる角度
    //[SerializeField]
    //private float slopeLimit = 65f;
    ////　昇れる段差の位置から飛ばすレイの距離
    //[SerializeField]
    //private float slopeDistance = 5f;
    // Use this for initialization
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        layerMask = ~(1 << LayerMask.NameToLayer("Player"));
    }//Start()

    // Update is called once per frame
    void Update()
    {
        if(state)
        {
            return;
        }
        //　確認の為レイを視覚的に見えるようにする
        Debug.DrawLine(stepRay.position + Vector3.up * 0.1f, stepRay.position + Vector3.down * d, Color.red);
       
        if (isGround)
        {
            
            moveVector = Vector3.zero;
            _horizontalInput = Input.GetAxis("Horizontal");    //左右矢印キーの値(-1.0~1.0)
            _verticalInput = Input.GetAxis("Vertical");      //上下矢印キーの値(-1.0~1.0)
            ////　ステップ用のレイが地面に接触しているかどうか
            //if (Physics.Linecast(stepRay.position, stepRay.position + stepRay.forward * stepDistance, out var stepHit, LayerMask.GetMask("Field", "Block")))
            //{
            //    //　進行方向の地面の角度が指定以下、または昇れる段差より下だった場合の移動処理

            //    if (Vector3.Angle(transform.up, stepHit.normal) <= slopeLimit
            //        || (Vector3.Angle(transform.up, stepHit.normal) > slopeLimit
            //            && !Physics.Linecast(transform.position + new Vector3(0f, stepOffset, 0f), transform.position + new Vector3(0f, stepOffset, 0f) + transform.forward * slopeDistance, LayerMask.GetMask("Field", "Block")))
            //    )
            //    {
            //        velocity = new Vector3(0f, (Quaternion.FromToRotation(Vector3.up, stepHit.normal) * transform.forward * moveSpeed).y, 0f) + transform.forward * moveSpeed;
            //        Debug.Log(Vector3.Angle(transform.up, stepHit.normal));

            //    }
            //    else
            //    {
            //        velocity += transform.forward * moveSpeed;
            //    }

            //    Debug.Log(Vector3.Angle(Vector3.up, stepHit.normal));
            //}

            // カメラの方向から、X-Z平面の単位ベクトルを取得
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            // 方向キーの入力値とカメラの向きから、移動方向を決定
            Vector3 moveForward = cameraForward * _verticalInput + Camera.main.transform.right * _horizontalInput;

            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            moveVector = moveForward * moveSpeed;
            if(moveVector == Vector3.zero)
            {
                anim.SetBool("isWalk",false);
            }
            else
            {
                anim.SetBool("isWalk", true);
            }
            if (Input.GetButtonDown("Jump")) //　ジャンプ
            {
                //　ジャンプしたら接地していない状態にする
                isGround = false;
                moveVector *= 0.6f;
                moveVector.y = jumpSpeed;
                anim.SetTrigger("Jump");
            }

            // キャラクターの向きを進行方向に
            if (moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveForward);
            }




        }//isGround
        else
        {
            moveVector.y -= 0.02f;
        }
    }
    void FixedUpdate()
    {

        
        _rb.MovePosition(transform.position + moveVector  * Time.fixedDeltaTime);

    }
    private void OnCollisionEnter(Collision collision)
    {
        
        //　地面に着地したかどうかの判定
        if (Physics.CheckSphere(stepRay.position, d, layerMask))
        {
            Debug.Log("on");
            isGround = true;
            moveVector.y = 0f;
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
                Debug.Log("off");
                isGround = false;
            }
        }
    }
}
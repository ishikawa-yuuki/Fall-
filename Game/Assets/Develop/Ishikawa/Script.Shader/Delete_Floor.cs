using UnityEngine;

public class Delete_Floor : MonoBehaviour
{
    private bool pose = false;
    private bool Falling;
    private float deleteTime = 0.6f;
    public int selectNum;
    private readonly Color[] materials = new Color[3];
    

    // Start is called before the first frame update
    void Start()
    {
        float t = Random.Range(0.0f, 0.2f);
        materials[0] = new Color(1.0f,1.0f-t,0.0f,1.0f);
        materials[1] = new Color(0.0f, 0.5f-t, 1.0f, 1.0f);
        materials[2] = new Color(0.8f-t, 0.0f, 1.0f, 1.0f);
        // 現在使用されているマテリアルを取得
        Material white_m = this.GetComponent<Renderer>().material;
        // マテリアルの色設定に赤色を設定
        white_m.color = materials[selectNum];
        this.GetComponent<Renderer>().material = white_m;
    }

    // Update is called once per frame
    void Update()
    {
        if(pose)
        {
            return;
        }
        if (Falling)
        {

            deleteTime -= Time.deltaTime;

            if (deleteTime <= 0)
            {
                this.gameObject.SetActive(false);
            }

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Falling = true;
            // 現在使用されているマテリアルを取得
            Color white_m = this.GetComponent<Renderer>().material.color;
            // マテリアルの色設定に赤色を設定
            white_m.a = 0.5f;
            this.GetComponent<Renderer>().material.color = white_m;
        }
    }
    public void SetPose(bool p)
    {
        pose = p;
    }
}

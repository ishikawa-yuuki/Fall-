using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 speed;//プレイヤーが所持する移動ベクトル。

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        //清算
        this.transform.position += speed;
        //リセット
        speed =new Vector3(0.0f, 0.0f, 0.0f);
    }

    //移動系
    public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            speed.x += 0.1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            speed.x -= 0.1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            speed.z -= 0.1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            speed.z += 0.1f;
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_Floor : MonoBehaviour
{
    private bool Falling;
    private float deleteTime = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        // 現在使用されているマテリアルを取得
        Material white_m = this.GetComponent<Renderer>().material;
        // マテリアルの色設定に赤色を設定
        white_m.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
        this.GetComponent<Renderer>().material = white_m;
    }

    // Update is called once per frame
    void Update()
    {
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tamacamera : MonoBehaviour
{
    //private GameObject player;   //プレイヤー情報格納用
    public Transform target;    //追従するターゲット。
    public Vector3 offset;  //プレイヤーとカメラの距離。

    // Start is called before the first frame update
    void Start()
    {
        //this.player = GameObject.Find("Player1");

        offset = new Vector3(-10.0f, 3.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {

        //カメラ向き
        //transform.rotation = player.transform.rotation;
        transform.position = target.position + offset;
        this.transform.LookAt(target.position);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class Main1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        //ルーム内のクライアントがMasterClientと同じシーンをロードするように設定
        PhotonNetwork.AutomaticallySyncScene = false;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (!PhotonNetwork.IsConnected)//接続を確認(切断できているかを知るため)
        {
            //できていれば遷移。
            SceneManager.LoadScene("result");
        }
        if (Input.GetMouseButtonDown(0))
        {
            //ネットワーク切断
            PhotonNetwork.Disconnect();

        }
    }
}

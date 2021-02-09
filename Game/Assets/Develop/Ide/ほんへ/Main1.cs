using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Main1 : MonoBehaviour
{
    private readonly int rast =1;
    public GameObject die =null;
    void Awake()
    {
       
        //ルーム内のクライアントがMasterClientと同じシーンをロードするように設定
        PhotonNetwork.AutomaticallySyncScene = false;
    }
    // Update is called once per frame
    void Update()
    {

        if (!PhotonNetwork.IsConnected && !die.GetComponent<Player_Die>().GetDead())//接続を確認(切断できているかを知るため)
        {
            //できていれば遷移。
            SceneManager.LoadScene("result");
            return;
        }
        if (rast == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            //ネットワーク切断
            PhotonNetwork.Disconnect();

        }
    }
}

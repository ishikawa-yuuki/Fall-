using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class Player_Die : MonoBehaviour
{
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
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //ネットワーク切断
            PhotonNetwork.Disconnect();
        }
    }
}

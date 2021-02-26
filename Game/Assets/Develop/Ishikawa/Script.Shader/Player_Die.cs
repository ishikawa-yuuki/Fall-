using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class Player_Die : MonoBehaviour
{
    private readonly int rast = 1;
    private bool die = false;
   private void Awake()
    {

        //ルーム内のクライアントがMasterClientと同じシーンをロードしないように設定
        PhotonNetwork.AutomaticallySyncScene = false;
    }
    // Update is called once per frame
   private void Update()
    {
        if (!PhotonNetwork.IsConnected)//接続を確認(切断できているかを知るため)
        {
            if(die)
            {
                //できていれば遷移。
                SceneManager.LoadScene("Menyu");
            }
            else if(!die)
            {
                //できていれば遷移。
                SceneManager.LoadScene("result");
            }
           
            return;
        }

        if (rast == PhotonNetwork.CurrentRoom.PlayerCount || die)
        {
            //ネットワーク切断
            PhotonNetwork.Disconnect();

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            die = true;
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class result1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
           //ネットワーク切断
            PhotonNetwork.Disconnect();

        }
        if (!PhotonNetwork.IsConnected)//接続を確認(切断できているかを知るため)
        {
            //できていれば遷移。
            SceneManager.LoadScene("Menyu");
        }
    }
}

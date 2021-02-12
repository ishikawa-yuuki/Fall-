using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class Player_Die : MonoBehaviour
{
    private bool die = false;
  
    // Update is called once per frame
    void Update()
    {
        if (!PhotonNetwork.IsConnected && die)//接続を確認(切断できているかを知るため)
        {
            //できていれば遷移。
            SceneManager.LoadScene("Menyu");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            die = true;
            //ネットワーク切断
            PhotonNetwork.Disconnect();
        }
    }
    public bool GetDead()
    {
        return die;
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class menyu2 : MonoBehaviourPunCallbacks
{
    public void OnClicStartButton()
    {
        //SceneManager.LoadScene("Main");
        //Photonに接続できていなければ
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();   //Photonに接続する
            Debug.Log("Photonに接続しました。");
            SceneManager.LoadScene("RoomCreate");
        }

    }
}

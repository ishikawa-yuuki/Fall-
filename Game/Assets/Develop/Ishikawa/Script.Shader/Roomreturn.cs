using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Roomreturn : MonoBehaviourPunCallbacks
{
    public void OnClicRetuButton()
    {
        if (PhotonNetwork.InRoom)
        {
            // 退室
            PhotonNetwork.LeaveRoom();
            Debug.Log("LeaveRoom");
        }
    }
    
   
  
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.LoadLevel("RoomCreate");
        Debug.Log("OnConnectedToMaster");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class ListUpdate : MonoBehaviourPunCallbacks
{
    public void OnClicRetuButton()
    {
        if (PhotonNetwork.InLobby)
        {
            PhotonNetwork.LeaveLobby();
            PhotonNetwork.JoinLobby();
            Debug.Log("List更新");
        }
        
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class ListUpdate : MonoBehaviourPunCallbacks
{
    public GameObject joinText;
    public void OnClicRetuButton()
    {
        if (joinText.activeSelf)
        {
            return;
        }
        if (PhotonNetwork.InLobby)
        {
            PhotonNetwork.LeaveLobby();
            PhotonNetwork.JoinLobby();
            Debug.Log("List更新");
        }
        
    }

}
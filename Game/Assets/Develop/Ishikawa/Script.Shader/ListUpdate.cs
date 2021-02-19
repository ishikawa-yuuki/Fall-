using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class ListUpdate : MonoBehaviour
{
    public void OnClicRetuButton()
    {
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.JoinLobby();
        Debug.Log("List更新");
    }
}
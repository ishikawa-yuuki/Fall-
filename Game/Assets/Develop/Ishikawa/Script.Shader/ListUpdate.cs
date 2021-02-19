using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class ListUpdate : MonoBehaviour
{
    public GameObject joinText;
    public void OnClicRetuButton()
    {
        if (joinText.activeSelf)
        {
            return;
        }
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.JoinLobby();
        Debug.Log("List更新");
    }
}
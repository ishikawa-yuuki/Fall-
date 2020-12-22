using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class GamePlayerManager : MonoBehaviourPunCallbacks
{
    private List<GamePlayer> playerList = new List<GamePlayer>();
    public TextMeshProUGUI PlayerNumber;   //人数
    public GamePlayer this[int index] => playerList[index];
    public int Count => playerList.Count;
    private void OnTransformChildrenChanged()
    {
        // 子要素が変わったら、ネットワークオブジェクトのリストを更新する
        playerList.Clear();
        foreach (Transform child in transform)
        {
            playerList.Add(child.GetComponent<GamePlayer>());
        }
        if(PlayerNumber == null)
        {
            return;
        }
        PlayerNumber.text =  Count + "/" +PhotonNetwork.CurrentRoom.MaxPlayers;
        if (PhotonNetwork.IsMasterClient&&Count == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            GetComponent<Stage_Randam>().Randam_Stage();
           
        }
    }
    public int GetPlayerCount()
    {
        return Count;
    }
}
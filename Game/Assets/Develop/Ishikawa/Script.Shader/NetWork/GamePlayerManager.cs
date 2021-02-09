using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
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
        }//ルームを抜ける際のバグ訂正
        if (Count ==0 ||!PhotonNetwork.InRoom)
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
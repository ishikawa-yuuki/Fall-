using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CRoomElementScript : MonoBehaviour
{
    //Room情報UI表示用
    public TextMeshProUGUI RoomName;   //部屋名
    public TextMeshProUGUI PlayerNumber;   //人数

    //入室ボタンroomname格納用
    private string roomname;

    //GetRoomListからRoom情報をRoomElementにセットしていくための関数
    public void SetRoomInfo(string _RoomName, int _PlayerNumber, int _MaxPlayer)
    {
        //入室ボタン用roomname取得
        roomname = _RoomName;
        RoomName.text = " " + _RoomName;
        PlayerNumber.text = " " + _PlayerNumber + "/" + _MaxPlayer;
    }

    //入室ボタン処理
    public void OnJoinRoomButton()
    {
        //roomnameの部屋に入室
        PhotonNetwork.JoinRoom(roomname);
    }
}
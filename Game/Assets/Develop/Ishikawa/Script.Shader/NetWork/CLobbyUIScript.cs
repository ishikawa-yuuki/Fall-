﻿using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class CLobbyUIScript : MonoBehaviour
{
    //部屋作成ウインドウ表示用ボタン
    public Button OpenRoomPanelButton;

    //部屋作成ウインドウ
    public GameObject CreateRoomPanel;  //部屋作成ウインドウ
    public TMP_InputField RoomNameText;           //作成する部屋名
    public Slider PlayerNumberSlider;   //最大入室可能人数用Slider
    public TextMeshProUGUI PlayerNumberText;       //最大入室可能人数表示用Text
    public Button CreateRoomButton;     //部屋作成ボタン
    public GameObject joinText;
    // Update is called once per frame
    void Update()
    {
       
        //部屋人数Sliderの値をTextに代入
        PlayerNumberText.text = PlayerNumberSlider.value.ToString();

    }

    //部屋作成ウインドウ表示用ボタンを押したときの処理
    public void OnClick_OpenRoomPanelButton()
    {
        //部屋作成ウインドウが表示していれば
        if (CreateRoomPanel.activeSelf)
        {
            //部屋作成ウインドウを非表示に
            CreateRoomPanel.SetActive(false);
        }
        else //そうでなければ
        {
            //部屋作成ウインドウを表示
            CreateRoomPanel.SetActive(true);
        }
    }

    //部屋作成ボタンを押したときの処理
    public void OnClick_CreateRoomButton()
    {
        if (joinText.activeSelf)
        {
            return;
        }
        //作成する部屋の設定
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;   //ロビーで見える部屋にする
        roomOptions.IsOpen = true;      //他のプレイヤーの入室を許可する
        roomOptions.MaxPlayers = (byte)PlayerNumberSlider.value;    //入室可能人数を設定

        //ロビーにカスタムプロパティの情報を表示させる
        roomOptions.CustomRoomPropertiesForLobby = new string[]
        {
            "RoomCreator",
        };
        // 部屋名がなければデフォルトの部屋名を設定
        if (string.IsNullOrEmpty(RoomNameText.text))
        {
            RoomNameText.text += "MyRoom"+Random.Range(0,9999);
        }
        //部屋作成
        PhotonNetwork.CreateRoom(RoomNameText.text, roomOptions, null);
        
        
    }
}
﻿using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

namespace Com.MyCompany.MyGame
{
    public class LobbyManagerScript : MonoBehaviourPunCallbacks
    {
        #region Public Variables
        //部屋一覧表示用オブジェクト
        public GameObject RoomParent;//ScrolViewのcontentオブジェクト
        public GameObject RoomElementPrefab;//部屋情報Prefab
        public GameObject joinText;
        #endregion

        #region MonoBehaviour CallBacks
        void Awake()
        {
            //ルームから退室したら通る用
            if (PhotonNetwork.IsConnectedAndReady)
            {
                joinText.SetActive(false);
            }
            //ルーム内のクライアントがMasterClientと同じシーンをロードするように設定
            PhotonNetwork.AutomaticallySyncScene = true;
        }
       
        #endregion

        #region Public Methods
        public void GetRooms(List<RoomInfo> roomInfo)
        {
            //ルームが無ければreturn
            if (roomInfo == null || roomInfo.Count == 0) return;

            //ルームがあればRoomElementでそれぞれのルーム情報を表示
            for (int i = 0; i < roomInfo.Count; i++)
            {
                //Debug.Log(roomInfo[i].Name + " : " + roomInfo[i].Name + "–" + roomInfo[i].PlayerCount + " / " + roomInfo[i].MaxPlayers /*+ roomInfo[i].CustomProperties["roomCreator"].ToString()*/);

                //ルーム情報表示用RoomElementを生成
                GameObject RoomElement = GameObject.Instantiate(RoomElementPrefab);

                //RoomElementをcontentの子オブジェクトとしてセット    
                RoomElement.transform.SetParent(RoomParent.transform);
                //RoomElementにルーム情報をセット
                RoomElement.GetComponent<CRoomElementScript>().SetRoomInfo(roomInfo[i].Name, roomInfo[i].PlayerCount, roomInfo[i].MaxPlayers,joinText);
            }
        }

        //RoomElementを一括削除
        public static void DestroyChildObject(Transform parent_trans)
        {
            for (int i = 0; i < parent_trans.childCount; ++i)
            {
                GameObject.Destroy(parent_trans.GetChild(i).gameObject);
            }
        }
        #endregion

        #region MonoBehaviourPunCallbacks

        //GetRoomListは一定時間ごとに更新され、その更新のタイミングで実行する処理
        // ルームリストに更新があった時
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            if (joinText.activeSelf)
            {
                return;
            }
            Debug.Log("ルームリストが更新されました");
            DestroyChildObject(RoomParent.transform);   //RoomElementを削除
            GetRooms(roomList);
        }
        // マスターサーバーへの接続が成功した時に呼ばれるコールバック
        public override void OnConnectedToMaster()
        {
            joinText.SetActive(false);
            PhotonNetwork.JoinLobby();
        }
        // ロビーに入った時の処理
        public override void OnJoinedLobby()
        {
            
           joinText.SetActive(false);
            
            Debug.Log("ロビーに入りました。");
        }

        //ルームに入室時の処理
        public override void OnJoinedRoom()
        {
            Debug.Log("ルームに入室");
          
        }
        //ルーム作成時の処理(作成者しか実行されない)
        public override void OnCreatedRoom()
        {
            //ルームへ遷移
            PhotonNetwork.LoadLevel("Room");
        }
        #endregion
    }
}
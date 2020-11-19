using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class Room : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    private void Start()
    {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    // マッチングが成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
        var v = new Vector3(Random.Range(-5f, 5f), 5, Random.Range(-5f, 5f));
        //Photonに接続していれば自プレイヤーを生成
        GameObject Player = PhotonNetwork.Instantiate(this.playerPrefab.name, v, Quaternion.identity, 0);
    }

}

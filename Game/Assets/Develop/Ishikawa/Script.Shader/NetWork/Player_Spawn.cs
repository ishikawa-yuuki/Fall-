using Photon.Pun;
using UnityEngine;


public class Player_Spawn : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;     //スポーンするprefab
    public  GameObject[] spawn;         //スポーン地点
    private void Start()
    {
        //size = Random.Range(0, 3);
        //var gamePlayerManager = GameObject.FindWithTag("GamePlayerManager").GetComponent<GamePlayerManager>();


        //Vector3 v = spawn[size].transform.position;
        //// マッチング後、スポーン地点を取得して自分自身のネットワークオブジェクトを生成する
        ////Photonに接続していれば自プレイヤーを生成
        //PhotonNetwork.Instantiate(this.playerPrefab.name, v, Quaternion.identity, 0);
        PlayerInstantiate();
        
    }
   private void PlayerInstantiate()
    {
        Vector3 v = spawn[PhotonNetwork.LocalPlayer.GetHashCode()].transform.position;
        // マッチング後、スポーン地点を取得して自分自身のネットワークオブジェクトを生成する
        //Photonに接続していれば自プレイヤーを生成
        PhotonNetwork.Instantiate(this.playerPrefab.name, v, Quaternion.identity, 0);

    }

}

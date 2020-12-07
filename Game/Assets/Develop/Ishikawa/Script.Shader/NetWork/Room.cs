using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class Room : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    private void Start()
    {
        // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
        var v = new Vector3(Random.Range(-5f, 5f), 5, Random.Range(-5f, 5f));
        //Photonに接続していれば自プレイヤーを生成
        GameObject Player = PhotonNetwork.Instantiate(this.playerPrefab.name, v, Quaternion.identity, 0);
       
    }

  
}



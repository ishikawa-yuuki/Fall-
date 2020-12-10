using Photon.Pun;
using UnityEngine;


public class Player_Spawn : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;     //スポーンするprefab
    public  GameObject[] spawn;         //スポーン地点
    private int size = 0;               //スポーン地点の数
    private void Start()
    {
        size = spawn.Length;
        var gamePlayerManager = GameObject.FindWithTag("GamePlayerManager").GetComponent<GamePlayerManager>();
        for(int i=0; i<size; ++i)
        {

            if (i == gamePlayerManager.Count)
            {

                Vector3 v = spawn[i].transform.position;
                // マッチング後、スポーン地点を取得して自分自身のネットワークオブジェクトを生成する
                //Photonに接続していれば自プレイヤーを生成
                 PhotonNetwork.Instantiate(this.playerPrefab.name, v, Quaternion.identity, 0);
                return;
            }
        }
        
        

    }


}

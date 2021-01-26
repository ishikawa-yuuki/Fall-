using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace SelectCharacter
{
    public class Room : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private MyGameManagerData myGameManagerData = null;
        private void Start()
        {
            // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
            var v = new Vector3(Random.Range(-5f, 5f), 5, Random.Range(-5f, 5f));
            //Photonに接続していれば自プレイヤーを生成
            GameObject Player = PhotonNetwork.Instantiate(myGameManagerData.GetCharacter().name, v, Quaternion.identity, 0);

        }


    }
}



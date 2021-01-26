using Photon.Pun;
using UnityEngine;

namespace SelectCharacter
{
    public class Player_Spawn : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private MyGameManagerData myGameManagerData = null;
        public GameObject[] spawn;         //スポーン地点
        private void Start()
        {

            PlayerInstantiate();

        }
        private void PlayerInstantiate()
        {
            
            //ローカルIDが１から始まるので1引く。
            Vector3 v = spawn[PhotonNetwork.LocalPlayer.GetHashCode() - 1].transform.position;
            // マッチング後、スポーン地点を取得して自分自身のネットワークオブジェクトを生成する
            //Photonに接続していれば自プレイヤーを生成
            PhotonNetwork.Instantiate(myGameManagerData.GetCharacter().name, v, Quaternion.identity, 0);

        }

    }
}

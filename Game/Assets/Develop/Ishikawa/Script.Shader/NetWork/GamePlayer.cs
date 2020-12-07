using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GamePlayer : MonoBehaviourPunCallbacks
{
    //public Player Owner => photonView.Owner;

    private void Awake()
    {
        
        var gamePlayerManager = GameObject.FindWithTag("GamePlayerManager").GetComponent<GamePlayerManager>();
        transform.SetParent(gamePlayerManager.transform);
    }
  
    // 省略
}

using UnityEngine;
using Photon.Pun;
public class Stage_Randam : MonoBehaviour
{
    //ランダムにステージを選ぶ
   public void Randam_Stage()
    {
        int i;
        string[] names = new string[] { "Jump_ShowDown", "Hexagon" };
         i = Random.Range(0, names.Length);
        PhotonNetwork.LoadLevel(names[i]);
    }
}

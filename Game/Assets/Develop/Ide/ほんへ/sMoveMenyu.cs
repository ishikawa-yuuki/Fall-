using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class sMoveMenyu : MonoBehaviour
{
    private bool clic = false;
    public void OnClicStartButton()
    {
        clic = true;
    }
    void Update()
    {
        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("Menyu");
        }
        if (clic)
        {
            //ネットワーク切断
            PhotonNetwork.Disconnect();
        }
    }
}

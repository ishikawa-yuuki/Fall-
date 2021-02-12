using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class sMoveMenyu : MonoBehaviour
{
    private bool clic = false;
    public bool test = false;
    public void OnClicStartButton()
    {
        if (test)
        {
            SceneManager.LoadScene("Menyu");
        }
        else
        {
            clic = true;
        }
       
    }
    void Update()
    {
        if (!test)
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
}

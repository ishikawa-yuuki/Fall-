using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class result1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Menyu");

        }
    }
}

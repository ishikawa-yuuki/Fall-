using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDemo : MonoBehaviour
{

    public GameObject PL;
    float seconds;
    // Start is called before the first frame update
    void Start()
    {
        PL.GetComponent<PlayerDemo>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 4)
        {
            PL.GetComponent<PlayerDemo>().enabled = true;
        }
            
        }

}

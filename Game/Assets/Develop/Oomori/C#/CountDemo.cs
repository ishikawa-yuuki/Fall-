using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDemo : MonoBehaviour
{

    public GameObject PL;
    public GameObject PL2;
    float seconds;
    // Start is called before the first frame update
    void Start()
    {
        PL.GetComponent<Jump_demo>().enabled = false;
        PL2.GetComponent<Jump_demo2>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 4)
        {
            PL2.GetComponent<Jump_demo2>().enabled = true;
        PL.GetComponent<Jump_demo>().enabled = true;
        }
            
        }

}

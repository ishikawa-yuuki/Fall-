using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDemo : MonoBehaviour
{

    public Text CountText;

    float countdown = 4f;
    int count;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
            CountText.text = count.ToString();
        }

        if (countdown <= 0)
        {
            CountText.text = "";

        }
    }

}

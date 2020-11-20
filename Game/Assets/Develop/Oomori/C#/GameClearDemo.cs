using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearDemo : MonoBehaviour
{
    GameObject gameC;
    GameObject gameO;
    // Start is called before the first frame update
    void Start()
    {
        gameC = GameObject.Find("GameClear");
        gameC.GetComponent<Text>().enabled = false;
    }
    public void GameClear()
    {
        gameC.GetComponent<Text>().enabled = true;
        Debug.Log("ok");
    }

}

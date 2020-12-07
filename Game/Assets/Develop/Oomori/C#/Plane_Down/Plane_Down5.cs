using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Down5 : MonoBehaviour
{
//    float seconds;

//    private Animator anim;

//    // Start is called before the first frame update
//    void Start()
//    {
//        anim = GetComponent<Animator>();
//        anim.SetBool("Plane_Down", false);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        seconds += Time.deltaTime;
//        if (seconds >= 95)
//        {
//            anim.SetBool("Plane_Down", true);
//            seconds = 0;

//        }
//    }
    private Animator anime;
    bool anim;
    void Start()
    {
    anime = GetComponent<Animator>();
    anime.SetBool("Plane_Down", false);
    }
    void Update()
    {   
    if (anim == false)
    {
        // 1.0秒から5.0秒の間のランダムな時間でSpawnObject()を呼び出す
        // 都合のよい値に変えてください
        Invoke("SpawnObject", Random.Range(30.0f, 50.0f));
        // SpawnObject()を呼び出し待機中につき呼び出されるまではInvake()を呼ばないようにする
        anim = true;


        }
    }
    void SpawnObject()
    {

    anim = false;
    anime.SetBool("Plane_Down", true);
    Debug.Log("6");
    }
}

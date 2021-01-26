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
    public bool Plane_Down5Anim;
    public GameObject plane5;
    void Start()
    {
    anime = GetComponent<Animator>();
    anime.SetBool("Plane_Down", false);
    }
    void Update()
    {
        if (Plane_Down5Anim == false)
        {
            // 1.0秒から5.0秒の間のランダムな時間でSpawnObject()を呼び出す
            // 都合のよい値に変えてください
            Invoke("SpawnObject", Random.Range(40.0f, 120.0f));
            // SpawnObject()を呼び出し待機中につき呼び出されるまではInvake()を呼ばないようにする
            Plane_Down5Anim = true;


        }
    }
    void SpawnObject()
    {

        Plane_Down5Anim = false;
        anime.SetBool("Plane_Down", true);
        Destroy(plane5, 2.5f);
        
        Debug.Log("6");
        
    }
}

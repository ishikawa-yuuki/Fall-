﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Down7 : MonoBehaviour
{
    //float seconds;

    //private Animator anim;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    anim = GetComponent<Animator>();
    //    anim.SetBool("Plane_Down", false);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    seconds += Time.deltaTime;
    //    if (seconds >= 110)
    //    {
    //        anim.SetBool("Plane_Down", true);
    //        seconds = 0;

    //    }
    //}
    private Animator anime;
    public bool Plane_Down7Anim;
    public GameObject plane7;
    void Start()
    {
        anime = GetComponent<Animator>();
        anime.SetBool("Plane_Down", false);
    }
    void Update()
    {
        if (Plane_Down7Anim == false)
        {
            // 1.0秒から5.0秒の間のランダムな時間でSpawnObject()を呼び出す
            // 都合のよい値に変えてください
            Invoke("SpawnObject", Random.Range(40.0f, 120.0f));
            // SpawnObject()を呼び出し待機中につき呼び出されるまではInvake()を呼ばないようにする
            Plane_Down7Anim = true;


        }
    }
    void SpawnObject()
    {

        Plane_Down7Anim = false;
        anime.SetBool("Plane_Down", true);
        Destroy(plane7, 2.5f);
        Debug.Log("a");
        
    }
}

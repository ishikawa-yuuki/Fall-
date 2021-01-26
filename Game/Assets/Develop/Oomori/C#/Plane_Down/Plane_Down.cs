using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Down : MonoBehaviour
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
    //        if (seconds >= 30)
    //        {
    //            anim.SetBool("Plane_Down", true);


    //        }
    //    }
    private Animator Plane_DownAnimator;
   public bool Plane_DownAnim;
    public GameObject plane;
    void Start()
        {
          Plane_DownAnimator = GetComponent<Animator>();
          Plane_DownAnimator.SetBool("Plane_Down", false);
       }
    void Update()
    {
        if (Plane_DownAnim == false)
        {
            // 1.0秒から5.0秒の間のランダムな時間でSpawnObject()を呼び出す
            // 都合のよい値に変えてください
            Invoke("SpawnObject", Random.Range(40.0f, 120.0f));
            // SpawnObject()を呼び出し待機中につき呼び出されるまではInvake()を呼ばないようにする
            Plane_DownAnim = true;


           
        }
                
    }
    void SpawnObject()
    {
       
        Plane_DownAnim = false;
        Plane_DownAnimator.SetBool("Plane_Down", true);
        Destroy(plane, 2.5f);
        Debug.Log("a");
    }
}

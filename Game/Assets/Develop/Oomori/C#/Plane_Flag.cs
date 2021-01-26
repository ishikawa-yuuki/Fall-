using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Flag : MonoBehaviour
{
   
    
    private Animator Plane_Down4Animator;
   
    public bool Plane_Down4Anim;
    public GameObject plane4;
    public int iRandNum;
    // Start is called before the first frame update
    void Start()
    {
        Plane_Down4Animator = GetComponent<Animator>();
        Plane_Down4Animator.SetBool("Plane_Down4", false);

        iRandNum = Random.Range(0, 2);


    }

    // Update is called once per frame
    void Update()
    {
        if (Plane_Down4Anim == false)
        {
            if (iRandNum == 0)
            {
                // 1.0秒から5.0秒の間のランダムな時間でSpawnObject()を呼び出す
                // 都合のよい値に変えてください
                Invoke("SpawnObject", Random.Range(40.0f, 120.0f));
                // SpawnObject()を呼び出し待機中につき呼び出されるまではInvake()を呼ばないようにする
                Plane_Down4Anim = true;
                Debug.Log("p4");
            }
            
        }
    }

    void SpawnObject()
    {

        Plane_Down4Anim = false;
        Plane_Down4Animator.SetBool("Plane_Down4", true);
        Destroy(plane4, 2.5f);
        Debug.Log("a");
    }
}

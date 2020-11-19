using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Down2 : MonoBehaviour
{
    float seconds;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Plane_Down", false);
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 50)
        {
            anim.SetBool("Plane_Down", true);
            seconds = 0;

        }
    }
}

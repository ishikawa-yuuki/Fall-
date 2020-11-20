using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultFlagCaller : MonoBehaviour
{
    
    //GoalCount  GoalC;
    public BoxCollider box;
    private FlagCaller fc;
    // Start is called before the first frame update
    void Start()
    {
        
        //GoalC = GetComponent<GoalCount>();
        fc = GetComponent<FlagCaller>();
    }
  
      void Update()
    {
        if (fc.check_1 == true)
        {
            box.enabled = true;
        }
     //if (GoalC.GoalFlags == true)
       // {
         //   box.enabled = true;
       // }

    }
}

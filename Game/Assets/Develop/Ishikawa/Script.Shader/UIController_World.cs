using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController_World : MonoBehaviour
{
    private RectTransform myRectTfm;
    [SerializeField]
    private bool state = true;
    void Start()
    {
        myRectTfm = GetComponent<RectTransform>();
        gameObject.SetActive(state);
    }

    void Update()
    {
        // 自身の向きをカメラに向ける
        myRectTfm.LookAt(Camera.main.transform);
    }
}

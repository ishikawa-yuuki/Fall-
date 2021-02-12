using UnityEngine;

public class UIController_World : MonoBehaviour
{
    private RectTransform myRectTfm;
    [SerializeField]
    private bool state = false;
    void Start()
    {
        myRectTfm = GetComponent<RectTransform>();
        gameObject.SetActive(state);
    }

    void Update()
    {
        gameObject.SetActive(state);
        // 自身の向きをカメラに向ける
        myRectTfm.LookAt(Camera.main.transform);
    }
   public void SetState(bool s)
    {
        state = s;
    }
}

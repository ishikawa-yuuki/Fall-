using UnityEngine;

public class Count_kari : MonoBehaviour
{
    [SerializeField]
    private GameObject ParentObject = null;
    [SerializeField]
    private GameObject P_ParentObject = null;

    private GameObject[] P_ChildObject;
    private GameObject[] ChildObject;
    bool stop = false;
    float seconds;
    // Start is called before the first frame update
    void Start()
    {
        GetAllChildObject();
        for (int i = 0; i < ParentObject.transform.childCount; i++)
        {
            ChildObject[i].GetComponent<Delete_Floor>().SetPose(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            return;
        }
        seconds += Time.deltaTime;
        if (seconds >= 4)
        {
            //床
            for (int i = 0; i < ParentObject.transform.childCount; i++)
            {
                ChildObject[i].GetComponent<Delete_Floor>().SetPose(false);
            }
            //player
            for (int i = 0; i < P_ParentObject.transform.childCount; i++)
            {
                P_ChildObject[i].GetComponent<N_Player_Move>().SetPose(false);
            }
            stop = true;
            return;
        }
        GetAllChildObjectP();
        for (int i = 0; i < P_ParentObject.transform.childCount; i++)
        {
            P_ChildObject[i].GetComponent<N_Player_Move>().SetPose(true);
        }
    }

    private void GetAllChildObject()//子オブジェクトを取得yuka
    {
        ChildObject = new GameObject[ParentObject.transform.childCount];

        for (int i = 0; i < ParentObject.transform.childCount; i++)
        {
            ChildObject[i] = ParentObject.transform.GetChild(i).gameObject;
        }
    }
    private void GetAllChildObjectP()//子オブジェクトを取得player
    {
        P_ChildObject = new GameObject[P_ParentObject.transform.childCount];

        for (int i = 0; i < P_ParentObject.transform.childCount; i++)
        {
            P_ChildObject[i] = P_ParentObject.transform.GetChild(i).gameObject;
        }
    }
}

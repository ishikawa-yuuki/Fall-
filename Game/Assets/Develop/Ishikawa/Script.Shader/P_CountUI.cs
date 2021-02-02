using UnityEngine;
using TMPro;
public class P_CountUI : MonoBehaviour
{
    private int playerNum;
    private int clearNum =1;
    public TextMeshProUGUI PlayerNumber;   //人数

    // Update is called once per frame
    void Update()
    {
        playerNum = GetComponent<GamePlayerManager>().GetPlayerCount();
        PlayerNumber.text = clearNum + "/" + playerNum;
    }
}

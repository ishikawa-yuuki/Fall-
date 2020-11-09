using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalCount : MonoBehaviour
{
    // スコアを表示する
    public Text scoreText;
    // ハイスコアを表示する
    public Text highScoreText;  
    // スコア
    private int score;
    // PlayerPrefsで保存するためのキー
    private string highScoreKey = "highScore";

    //public bool GoalFlags = false;
    private FlagCaller fc;
    private GameClearDemo gameClearD;

    void Start()
    {
        Initialize();
        // GoalFlags = false;
        fc = GetComponent<FlagCaller>();
        //fc.check_1 = false;
        gameClearD = GetComponent<GameClearDemo>();

    }
    void Update()
    {

        // スコア・ハイスコアを表示する
        scoreText.text = score.ToString();

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerAI")
        {
            score++;
            // GoalFlags = true;
            //fc.check_1 = true;
            //text.GetComponent<Text>().enabled = true;
            GameObject.Find("Canvas").GetComponent<GameClearDemo>().GameClear();
        }
    }
   
    // ゲーム開始前の状態に戻す
    private void Initialize()
    {
        // スコアを0に戻す
        score = 0;

        // ハイスコアを取得する。保存されてなければ0を取得する。
        //highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    //// ポイントの追加
    //public void AddPoint(int point)
    //{
    //    score = score + point;
    //}

    // ハイスコアの保存
    public void Save()
    {
      
        // ゲーム開始前の状態に戻す
        Initialize();
    }
}

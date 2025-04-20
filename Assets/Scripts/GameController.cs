using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
//ボタン型を使えるようにする

public class GameController : MonoBehaviour
{
    private const string Name = "DropScore";
    public int score = 0;
    //獲得スコア用の変数
    public int DropScore = 0;
    //未獲得スコア用の変数
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI DropScoreText;
    public GameObject WinText;
    public GameObject GameOver;

    public Button button;
    public Button button1;
    private DropObject1 _dropobject1;
    private DropObject2 _dropobject2;

    // Start is called before the first frame update
    void Start()
    {
        _dropobject1 = GameObject.Find("1").GetComponent<DropObject1>();
        _dropobject2 = GameObject.Find("2").GetComponent<DropObject2>();
        SetCountText();
        //this.scoretext = GameObject.Find("Score");
        //this.Dropscore = GameObject.Find("DropScore");
        WinText.SetActive(false);
        GameOver.SetActive(false);
        button.gameObject.SetActive(false);
        button1.gameObject.SetActive(false);
    }
    //スコア代入
    public void addscore1()
    {
        if((score <= 10)&&(DropScore <= 50))
        {
            this.score += 1;
            //Debug.Log("1単位修得！");
        }
        
    }

    public void addDropScore1()
    {
        if((score <= 10)&&(DropScore <= 50))
        {
            this.DropScore += 1;
            //Debug.Log("1単位落とした！");
        }
        
    }

    public void addscore2()
    {
        if((score <= 10)&&(DropScore <= 50))
        {
            this.score += 2;
            //Debug.Log("2単位修得！");
        }
        
    }

    public void addDropScore2()
    {
        if((score <= 10)&&(DropScore <= 50))
        {
            this.DropScore += 2;
            //Debug.Log("2単位落とした！");
        }
        
    }

    public void SetCountText()
    {
        ScoreText.text = "Score:" + score.ToString() ;
        DropScoreText.text = "DropScore:" + DropScore.ToString();
        if(score >= 10)
        {
            WinText.SetActive(true);
            button.gameObject.SetActive(true);
            button1.gameObject.SetActive(true);
        }else if(DropScore >= 50)
        {
            GameOver.SetActive(true);
            button.gameObject.SetActive(true);
            button1.gameObject.SetActive(true);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

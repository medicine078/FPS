using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //uGUIを利用する際に必要

public class GameManager : MonoBehaviour
{
    BulletAction ba;
    public enum MODE
    {
        TITLE,
        PLAY,
        OVER,
        CLEAR
    }
    public MODE GameMode; //ゲームモード

    [SerializeField] Text txtCount; //画面のGUI文字
    [SerializeField] Text txtMessage;
    [SerializeField] Text txtOver;
    [SerializeField] Text txtClear;
    public float Cnt; //カウント領域


    //public GameObject[] Ball = new GameObject[9];
    [SerializeField] GameObject[] ballPrefab;
    [SerializeField] GameObject[] pos_obj;
    [SerializeField] GameObject ballParent;

    public bool GameClear_flg;
    public bool GameOver_flg;

    public bool gameStart;
    public bool gameFinish;

    public bool Time_flg;

    public int nextTarget;


    void Start()
    {
        SetTitle();
    }

    void SetTitle()
    {
        GameMode = MODE.TITLE;

        gameStart = false;
        gameFinish = false;
        Time_flg = false;

        ba = GetComponent<BulletAction>();

        nextTarget = 1;

        for (int i = 0; i < ballPrefab.Length; i++)
        {
            Instantiate(ballPrefab[i], pos_obj[i].transform.position, ballPrefab[i].transform.rotation, ballParent.transform);
        }

        GameClear_flg = false;
        GameOver_flg = false;

        Cnt = 30.00f; //カウント領域をゼロクリア
        txtCount.text = string.Format("Time: {0:00.00}", Cnt); //数字を文字にして画面に転記する
    }
    void Update()
    {

        switch (GameMode)
        {
            case MODE.TITLE:
                txtMessage.enabled = true;
                txtCount.enabled = true;
                txtOver.enabled = false;
                txtClear.enabled = false;
                
                txtMessage.text = "Push To EnterKye";
                Cnt = 30.00f; //カウント領域をゼロクリア
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    GameMode = MODE.PLAY;
                    txtMessage.enabled = false;
                }
                break;
            case MODE.PLAY:
                gameStart = true;
                if (Cnt > 0 && Time_flg == true)
                {
                    Cnt -= Time.deltaTime;//時間を減らしていく
                    txtCount.text = string.Format("Time: {0:00.00}", Cnt);
                    GameMode = MODE.PLAY;
                }
                else if (Cnt <= 0)
                {
                    GameMode = MODE.OVER;
                }

                if (gameFinish)
                {
                    GameMode = MODE.CLEAR;
                }
                break;
            case MODE.OVER:
                txtCount.enabled = false;
                txtOver.enabled = true;
                txtMessage.text = "GAME OVER";
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SetTitle();
                    GameMode = MODE.TITLE;
                }
                break;
            case MODE.CLEAR:
                txtClear.enabled = true;
                txtMessage.text = "CLEAR";
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SetTitle();
                    GameMode = MODE.TITLE;
                }
                break;
            default:
                break;
        }
    }
    
    //void BallInstance()
    //{
    //    for(int i =0;i<9;i++)
    //    {
    //        Instantiate(Ball[i], Ball[i].transform.position,Ball[i].transform.rotation); 
    //    }
    //}

    //void Start_timer(bool a)
    //{
    //    if (a == true)
    //    {
    //        Start_time = true;//タイマーを開始する
    //    }
    //    else
    //    {
    //        Start_time = false;
    //    }
    //}
   
}

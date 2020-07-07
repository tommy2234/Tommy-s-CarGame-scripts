using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//標題的腳本
public class TitleCtl : MonoBehaviour    //放在GameUI/Title
{
    public carctl Car;                   //玩家控制器
    public SpawnEnemyCtl SpawnEnemy;     //敵人生產器
    public Fuelctl Fuel;                 //控制消耗油量
    public GameObject TitleText;         //標題文字
    public GameObject CountDown;         //倒數文字
    public PauseCtl Pause;             //控制暫停
    
    public static TitleCtl self;
    private void Awake()                //必須放在Awake(必須比Start快)
    {
        self=this;
        Car.bg.speed = 0;       //事先讓背景撥放速度=0
        Fuel.ShowFuel();        //事先顯示油量
        StartGame(false);       //一開始先暫停遊戲
    }
    private void Update()
    {
        //若按下enter
        if(Input.GetKeyDown(KeyCode.Return)|| Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CountDown.SetActive(true);    //顯示倒數文字
            TitleText.SetActive(false);   //隱藏標題文字
            this.enabled = false;
        }
    }
    public void StartGame(bool start)         //開始or暫停遊戲
    {
        //開始or關閉
        Car.enabled = start;           
        SpawnEnemy.enabled = start;
        Fuel.enabled = start;
        Pause.enabled = start;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuelctl : MonoBehaviour
{
    public static Fuelctl self;
    private void Awake()
    {
        self = this;
    }

    private int maxfuel = 100;     //最大油量
    private int fuel = 0;          //耗油量
    private string zero = "000";   //油量的0最多幾個
    private void Start()
    {
        int level = Mathf.Clamp(PlayerDateManager.self.data.Level, 0, 2);
        maxfuel = LevelCtl.self.Fuel[level];
        ShowFuel();          //顯示油量
        Invoke("Cut", 1);    // 1秒後執行cut
    }
    void Cut()
    {
        if (!PlayerDateManager.self.data.Stop)  //若遊戲還沒停止
        {
            fuel++;                                           //每次執行耗油量+1
            MenuCtl.self.TimeNum++;
            ShowFuel();

            if (maxfuel - fuel > 0)     //油量>0就繼續執行(耗油)
                Invoke("Cut", 1);       //一秒後執行Cut
            else
                PlayerDateManager.self.data.Lose = true;            //遊戲輸了

            if(maxfuel-fuel<=5)
                EffectPlayer.self.PlayEffect("Warning");
        }
    }

    public void ShowFuel()
    {
        string fuelStr = (maxfuel - fuel).ToString();     //設定剩餘油量
                                                          //將油量文字設成FUEL+(補0)+剩餘油量
        GetComponent<Text>().text = "FUEL " + zero.Substring(fuelStr.Length) + fuelStr;
    }
    public void GetFuel()      //取得油量
    {
        if(PlayerDateManager.self.data.Lose)
        {
            PlayerDateManager.self.data.Lose = false;
            Invoke("Cut", 1);       //一秒後執行Cut
        }
        fuel -= 10;
        if (fuel < 0)
            fuel = 0;
        ShowFuel();          //顯示油量
    }
}

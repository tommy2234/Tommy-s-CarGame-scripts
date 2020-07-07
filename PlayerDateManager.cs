using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家資料管理器
public class PlayerDateManager : MonoBehaviour
{
    public static PlayerDateManager self;   //建構式
    private void Awake()
    {
        self = this;
        //  Load();
        data = new PlayerData();    //新增一個PlayerData的資料
        //data.Level = 2;
    }
    public PlayerData data;      //宣告一個資料型態為PlayerData的資料 命名為Data

    public void Save()
    {

    }
    public void Load()
    {

    }

    /*private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Fuelctl.self.GetFuel();
        }
    }  */

    public void Default()
    {
        data.Stop = false;
        data.Lose = false;
        for(int i=0;i<EffectPlayer.self.audios.Count;i++)
        {
            EffectPlayer.self.audios[i].Pause();  //雖是暫停 其實是刪除並重整陣列
        }
    }
}

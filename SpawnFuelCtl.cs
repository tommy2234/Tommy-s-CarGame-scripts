using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//生產汽油
public class SpawnFuelCtl : MonoBehaviour
{
    public static SpawnFuelCtl self;
    private void Awake()
    {
        self = this;
    }

    private bool UseBool = false;

    private const string FuelPrefabPath = "Prefabs/Fuel";   //地雷的prefab路徑
    private Vector2 XRange = new Vector2(-3.7f, 1.3f);    //產生時的x軸範圍
    private void Start()
    {
        int level = Mathf.Clamp(PlayerDateManager.self.data.Level, 0, 2);
        UseBool = LevelCtl.self.UseFuel[level];
    }
    public void Spawn()
    { 
        if (UseBool)
        {
            //Random.Range的範圍
            float FuelPosX = Random.Range(XRange.x, XRange.y);    //從X軸隨機取得一位置生產
            //生產
            GameObject fuel = Instantiate(Resources.Load(FuelPrefabPath), transform) as GameObject;
            //更改油桶位置
            fuel.transform.localPosition += new Vector3(FuelPosX, 0, 0);
        }
    }
}
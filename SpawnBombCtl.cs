using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//生產地雷
public class SpawnBombCtl : MonoBehaviour
{
    public static SpawnBombCtl self;
    private void Awake()
    {
        self = this;
    }

    private bool UseBool = false;

    private const string BombPrefabPath = "Prefabs/Bomb";   //地雷的prefab路徑
    private Vector2 XRange = new Vector2(-3.7f, 1.3f);    //產生時的x軸範圍
    private void Start()
    {
        int level = Mathf.Clamp(PlayerDateManager.self.data.Level, 0, 2);
        UseBool = LevelCtl.self.UseFuel[level];
    }
    public void Spawn()
    {
        if(UseBool)
        {
            //Random.Range的範圍
            float BombPosX = Random.Range(XRange.x, XRange.y);    //從X軸隨機取得一位置生產
            //生產
            GameObject Bomb = Instantiate(Resources.Load(BombPrefabPath) , transform) as GameObject;
            //更改地雷位置
            Bomb.transform.localPosition += new Vector3(BombPosX, 0, 0);
        }
    }
}

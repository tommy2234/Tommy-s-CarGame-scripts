using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//玩家資料
[Serializable]     //將資料序列化
public class PlayerData
{ 
    public bool Stop;   //遊戲是否已停止
    public bool Lose;   //是否輸了
    public int Level;   //關卡數
}

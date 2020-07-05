using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//觸發爆炸特效的事件
public class ExplosionCtl : MonoBehaviour   //car/explosion
{
   void ExplosionEvent()    //爆炸事件(Animation)
    {
        carctl.self.BoomEnd();    //呼叫玩家汽車爆炸的尾端
    }
}

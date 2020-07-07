using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//控制地雷
public class BombCtl : MonoBehaviour
{
    private float MaxDistance = 13f;  
    void FixedUpdate()
    {
        float TrueSpeed = -carctl.self.bgspeed/2.35f;       //算出地雷真正該移動的速度
        transform.position += new Vector3(0, TrueSpeed, 0);
        //若這個物件位置 和 地雷產生器位置 距離超過 特定距離
        if (Vector3.Distance(transform.position, SpawnEnemyCtl.self.transform.position) > MaxDistance)
            Destroy(gameObject);   
    }   

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制初始敵人移動
public class StartEnemyCtl : MonoBehaviour       
{
    private float speed = 0.8f;         //敵人最大車速
    void FixedUpdate()
    {    
        transform.position += new Vector3(0, speed, 0);
    }
}

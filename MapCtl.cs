using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtl : MonoBehaviour
{
    public static MapCtl self;
    private void Awake()
    {
        self = this;
    }
    private float EndPos = 4.5f;       //小地圖終點位置
    private float MaxDistance = 0;     //小地圖所移動總距離
    private void Start()
    {
        MaxDistance=EndPos-transform.localPosition.y;   //取得小地圖移動總距離
    }

    public void MapMove()      //控制小地圖移動的函式
    {
        //每次小地圖都會移動一段距離(根據圈數)
        transform.localPosition += new Vector3(0, MaxDistance / RoundCtl.self.maxround, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KMctl : MonoBehaviour
{
    private int maxspeed = 200;   //車最高速(KM)
    void FixedUpdate()
    {
        int km = (int)(carctl.self.bgspeed * maxspeed);   //計算最大公里數的比例(當下時速)
        //將公里數的文字設成當下時數 並加上KM/H
        GetComponent<Text>().text = km.ToString() + " KM/H";    
        
    }
}

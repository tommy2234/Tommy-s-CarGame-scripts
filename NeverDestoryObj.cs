using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//生產不要刪除的物件的控制器
public class NeverDestoryObj : MonoBehaviour
{
    public GameObject[] NeverDestoryObjs;     //不要被刪的物件們
    public static bool IsSpawn = false;       //是否已經生產物件
    private void Awake()
    {
        if(!IsSpawn)      //若還沒生產物件
        {
            //生產物件
            for (int i = 0; i < NeverDestoryObjs.Length; i++)
            {
                GameObject obj = Instantiate(NeverDestoryObjs[i]);
                DontDestroyOnLoad(obj);     //不要因為換場景被刪除
            }
            IsSpawn = true;   //標示已生產
        }
    }
}

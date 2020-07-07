using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownCtl : MonoBehaviour
{
    public Transform StartEnemys;
    private int Num = 3;
    private void Start()
    {
        GetComponent<Text>().text = Num.ToString();
        EffectPlayer.self.PlayEffect("CountDown"); 
    }
    void CountDown()
    {
        Num--;
        if(Num>0)
        {
            GetComponent<Text>().text = Num.ToString();
        }
        else
        {
            GetComponent<Text>().text = "GO!";
            Destroy(StartEnemys.gameObject, 1f);
            for(int i=0;i<StartEnemys.childCount;i++)
            {
                StartEnemys.GetChild(i).GetComponent<StartEnemyCtl>().enabled = true;
            }
            Invoke("StartGame", 1f);
        }

    }
    void StartGame()
    {
        TitleCtl.self.StartGame(true);   //啟動遊戲
        gameObject.SetActive(false);     //隱藏自己
    }
}

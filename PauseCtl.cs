using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制暫停
public class PauseCtl : MonoBehaviour
{
    public bool PauseBool = false;  //暫停/開始
    public static PauseCtl self;
    private void Awake()
    {
        self = this;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))  //若按下大Enter鍵
        {
            PauseBool = !PauseBool;
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void Pause()
    {
        Time.timeScale = PauseBool ? 0 : 1;
        EffectPlayer.self.Pause(PauseBool);
    }
    
}

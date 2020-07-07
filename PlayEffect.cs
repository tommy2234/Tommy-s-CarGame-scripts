using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffect : MonoBehaviour
{
    public int MyID;
    private void Awake()
    {
        this.enabled = false;    //暫時關閉腳本
    }
    private void FixedUpdate()
    {
        //如果音樂片段撥放完畢且沒暫停
        if(!GetComponent<AudioSource>().isPlaying && !PauseCtl.self.PauseBool)
        {
            EffectPlayer.self.audios.RemoveAt(MyID);
            EffectPlayer.self.ResetID();
            Destroy(gameObject);     //就刪除物件
        }
    }
}

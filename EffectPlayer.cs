using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//生產播放音效的物件
public class EffectPlayer : MonoBehaviour
{
    public float MyVolumn = 1;
    public List<AudioSource> audios = new List<AudioSource>();

    public static EffectPlayer self;
    private void Awake()
    {
        self = this;
    }

    public GameObject PlayEffectObj;    //播放音效的物件


    private const string EffectPath = "Audios/";   //音效路徑
    public void PlayEffect(string name)   //播放音效(音效名)
    {
        //生產並取得音樂撥放器
        AudioSource aud = Instantiate(PlayEffectObj).GetComponent<AudioSource>();
        //更改音樂撥放器的音樂片段
        aud.clip = Resources.Load<AudioClip>(EffectPath + name);
        aud.Play();           //真正的播放指令
        aud.GetComponent<PlayEffect>().enabled = true;  //開啟音效控制器腳本
        aud.GetComponent<PlayEffect>().MyID = audios.Count;
        audios.Add(aud);
    }
    public AudioSource GetEffect(string name)  //生產並回傳音效(音效名)
    {
        //生產並取得音樂撥放器
        AudioSource aud = Instantiate(PlayEffectObj).GetComponent<AudioSource>();
        //更改音樂撥放器的音樂片段
        aud.clip = Resources.Load<AudioClip>(EffectPath + name);
        aud.Play();           //真正的播放指令
        aud.GetComponent<PlayEffect>().enabled = true;  //開啟音效控制器腳本
        audios.Add(aud);
        return aud;
    }
    public void Pause (bool pause)
    {
        for(int i=0;i<audios.Count;i++)
        {
            if (pause)
                audios[i].Pause();
            else
                audios[i].Play();
        }
    }

    public void ResetID()
    {
        for(int i=0;i<audios.Count;i++)
        {
            audios[i].GetComponent<PlayEffect>().MyID = i;
        }
    }
}

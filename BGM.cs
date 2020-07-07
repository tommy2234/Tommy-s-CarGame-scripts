using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BGM控制器
public class BGM : MonoBehaviour
{
    public static BGM self;
    private void Awake()
    {
        self = this;
    }

    AudioSource aud;
    private const string BGMPath = "Audios/";

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }
    private void PlayBGM(string name)
    {
        aud.clip = Resources.Load<AudioClip>(BGMPath + name);
        aud.Play();         //真正播放指令
    }
}

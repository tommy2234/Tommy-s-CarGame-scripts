using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneCtl : MonoBehaviour
{
    public static LoadingSceneCtl self;
    private void Awake()
    {
        self = this;
    }
    public void Loading()
    {
        GetComponent<Animation>().Play("FadeOut");
        Invoke("ChangeScene",0.5f);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(0);      //更換到編號0的場景
        //SceneManager.LoadScene("Main);
    }
}

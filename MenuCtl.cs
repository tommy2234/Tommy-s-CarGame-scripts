using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//選單控制器
public class MenuCtl : MonoBehaviour     //GameUI Menu
{
    public int TimeNum;
    public int HitNum;

    public static MenuCtl self;         //建構式
    private void Awake()
    {
        self = this;
    }

    public GameObject Menu_BG;       //選單背景
    public Text TimeText;
    public Text HitText;
    public Text BtnText;   //下一關/再來一次

    void Start()
    {
        Menu_BG.SetActive(false);      //隱藏選單背景
    }
    public void ShowResult()        //顯示結果
    {
        Menu_BG.SetActive(true);         //顯示選單背景
        TimeResult();
        HitResult();
        ChangeBtnText();     //更改下一關/再來一次的文字
    }

    void TimeResult()
    {
        int Min = TimeNum / 60;
        int Sec = TimeNum % 60;
        string MinStr = Min > 9 ? Min.ToString() : "0" + Min.ToString();
        string SecStr = Sec > 9 ? Sec.ToString() : "0" + Sec.ToString();
        TimeText.text = "花費時間 : " + MinStr + " : " + SecStr;
    }
    void HitResult()
    {
        HitText.text = "撞車次數 : " + HitNum.ToString() + "次";
    }
    public void AgainBtn()       //again buttom
    {
        if (!PlayerDateManager.self.data.Lose)    //若沒輸
            PlayerDateManager.self.data.Level++;    //下一關
        LoadingSceneCtl.self.Loading();     //重新讀取場景(無論輸贏)
        PlayerDateManager.self.Default();  //恢復預設
    }
    public void ExitBtn()      //leave buttom
    {
        Application.Quit();     //關閉遊戲的指令
    }
    public void ChangeBtnText()
    {
        BtnText.text = PlayerDateManager.self.data.Lose ? "再來一次" : "下一關";
    }
}

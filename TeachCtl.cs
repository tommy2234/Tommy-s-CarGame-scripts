using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//按鍵觸碰回饋
public class TeachCtl : MonoBehaviour
{
    public static TeachCtl self;
    private void Awake()
    {
        self = this;
    }

    public Image[] Arrows;       //上、左、右鍵

    private Color32 white = new Color32(255, 255, 255, 255);
    private Color32 gray = new Color32(150, 150, 150, 255);

    public void TouchArrow(int ID,bool touch)      //該按鍵是否被按下
    {
        Arrows[ID].color = touch ? gray : white;
    }
}

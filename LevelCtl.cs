using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCtl : MonoBehaviour
{
    [HideInInspector]
    public int[] EnemyType = new int[] { 1, 2, 3 };   //敵人or障礙物種類
    [HideInInspector]
    public int[] Fuel = new int[] { 100, 60, 30 };     //汽油最大油量
    [HideInInspector]
    public int[] Round = new int[] { 50, 70, 100 };    //抵達終點最大圈數   
    //生產敵人冷卻時間
    [HideInInspector]
    public float[] AddEnemyCD = new float[] { 2f, 1f, 0.5f };
    //是否啟用補充汽油的道具
    [HideInInspector]
    public bool[] UseFuel = new bool[] { false, false, true };
    public bool[] UseBomb = new bool[] { false, false, true };


    public static LevelCtl self;
    private void Awake()
    {
        self = this;
    }
    private void Start()
    {
        ShowLevel();
        int level = Mathf.Clamp(PlayerDateManager.self.data.Level, 0, 2);
        Debug.Log((level+1).ToString() + "關," + EnemyType[level] + "種敵人,最大油量" + Fuel[level] + ",最大圈數" + Round[level] + ",生產敵人冷卻時間" + AddEnemyCD[level] + ",是否啟用補油道具" + UseFuel[level] + ",是否啟用地雷" + UseBomb[level]);
    }
    public void ShowLevel()
    {
        int level = PlayerDateManager.self.data.Level+1;  //取得現在的關卡數
        GetComponent<Text>().text = "Level" + level.ToString();  //顯示關卡的文字 
    }    
}

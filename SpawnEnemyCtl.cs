using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyCtl : MonoBehaviour
{
    public static SpawnEnemyCtl self;
    private void Awake()
    {
        self = this;
    }

    private float AddEnemyCD;   //冷卻時間
    private float MaxAddEnemyCD = 0f;    //實際產生敵人的時間
    private float MaxDistance=6.5f;
    private int TypeNum;    //敵人的數量

    private const string EnemyPrefabPath = "Prefabs/enemy";   //敵人的prefab路徑
    private Vector2 XRange = new Vector2(-3.7f, 1.3f);    //敵人產生時的x軸範圍
    private void Start()
    {
        int level = Mathf.Clamp( PlayerDateManager.self.data.Level,0,2);
        TypeNum = LevelCtl.self.EnemyType[level];
        AddEnemyCD = LevelCtl.self.AddEnemyCD[level];
    }

    private void Update()
    {
        if(CanAdd() && !PlayerDateManager.self.data.Stop) //若現在生產敵人的位置是安全距離 且 遊戲還沒停止
        {
            Spawn();   //生產敵人的函式;
        }
    }

    public int ID;
    public GameObject enemy;
    public void Spawn()
    {
        if (Time.time >= MaxAddEnemyCD)
        {
            //Random.Range的範圍
            float PosX = Random.Range(XRange.x, XRange.y);    //從X軸隨機取得一位置生產敵人
            //生產敵人
            ID = Random.Range(0, TypeNum);
            enemy = Instantiate(Resources.Load(EnemyPrefabPath + ID.ToString()), transform) as GameObject;
            //更改敵人位置
            enemy.transform.localPosition += new Vector3(PosX, 0, 0);
            MaxAddEnemyCD = Time.time + AddEnemyCD;    //增加冷卻
        }
    }

    bool CanAdd()
    {
        int num = transform.childCount;    //取得子物件的數量
        bool safe = true;                  //先假設距離式OK的
        for (int i = 0; i < num; i++)
        {
            //取得第i個子物件位置
            Vector3 TempPos = transform.GetChild(i).transform.position;
            //取得自己位置(x軸歸零)
            Vector3 myPos = new Vector3(0, transform.position.y, transform.position.z);
            //取得第i個子物件位置(x軸歸零)
            Vector3 TempPos2 = new Vector3(0, TempPos.y, TempPos.z);
            //如果有任何一台車的距離是不安全的
            if(Vector3.Distance(myPos,TempPos2)<MaxDistance)
            {
                safe = false;  //設定為不安全
                break;     //跳出迴圈 
            }

        }

        return safe;
    }
}

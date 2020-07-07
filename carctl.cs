using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//控制玩家移動
public class carctl : MonoBehaviour
{
    public float bgspeed = 0;  //背景播放速度
    public float carposx = 0;  //車x軸位置
    public static carctl self;  //建構式
    private void Awake()
    {
        self = this;
    }

    public Animator bg;  //背景動畫控制器
    public GameObject Explosion;    //爆炸特效的物件

    private bool drivebool = false; //布林值 汽車是否需加速
    private bool IsHit = false;      //車是否在打滑
    private float addspeed = 0.005f;  //車加速度
    private float xmovespeed = 0.2f;  //車左右移動速度
    private float DefaultPosX;       //道路中間值

    private AudioSource aud; //汽車音效

    private Vector2 xmoverange = new Vector2(-3.7f, 1.3f);  //車左右(x軸)移動範圍
    private void Start()
    {
        DefaultPosX = transform.position.x;
        carposx = transform.localPosition.x;
        aud=EffectPlayer.self.GetEffect("Drive");  //生產並取得音效
        aud.loop = true;
        aud.pitch = 0;
    }
    void FixedUpdate()
    {
        move();  //控制向前
        if (!IsHit)   //若未打滑
            turn();  //控制左右
        else
            Rotate();
        
        aud.pitch=bg.speed = bgspeed; //控制背景撥放速度
        //控制車左右移動
        transform.localPosition = new Vector3(carposx, transform.localPosition.y, transform.localPosition.z);
        
        if(PlayerDateManager.self.data.Lose && bgspeed==0 )
        {
            EffectPlayer.self.PlayEffect("Fail");
            Stop();
        }
    }

    void move()
    {
        //是否按上鍵 且 遊戲未輸
        drivebool = Input.GetKey(KeyCode.UpArrow) && !PlayerDateManager.self.data.Lose; //按上鍵加速否則不加速
        TeachCtl.self.TouchArrow(0, drivebool);    //是否按上鍵

        if (drivebool == true) //若車正加速
            bgspeed += addspeed;  //車加速(增加背景撥放速度)
        else
            bgspeed -= addspeed;  //減少背景撥放速度

        if (bgspeed >= 1)
            bgspeed = 1;
        if (bgspeed <= 0)
            bgspeed = 0;
    }
    void turn()
    {
        bool RightBool = false;
        bool LeftBool = false;

        if (Input.GetKey(KeyCode.LeftArrow))  //若按住左箭頭
        {
            carposx -= xmovespeed;  //車左移
            LeftBool = true;
        }

        else if (Input.GetKey(KeyCode.RightArrow))  //若按住右箭頭
        {
            carposx += xmovespeed;  //車右移
            RightBool = true;
        }
        TeachCtl.self.TouchArrow(1, LeftBool);      //是否按左鍵
        TeachCtl.self.TouchArrow(2, RightBool);     //是否按右鍵

        carposx = Mathf.Clamp(carposx, xmoverange.x, xmoverange.y);  //限制車左右移動範圍

    }
    void Rotate()
    {
        if(carposx>=xmoverange.y||carposx<=xmoverange.x)
        {
            BoomStart();    //爆炸
            RotateReset();
        }
        if(bgspeed==0)
        {
            RotateReset();
        }
    }

    void RotateReset()
    {
        GetComponent<CarRotateCtl>().enabled = false;    //關閉打滑腳本
        transform.eulerAngles = Vector3.zero;    //重置旋轉軸
        IsHit = false;
    }

    void BoomStart()
    {
        EffectPlayer.self.PlayEffect("Explosion");
        for(int i=0;i<3;i++)
        {
            TeachCtl.self.TouchArrow(i, false);
        }
        Debug.Log("已發生爆炸");
        aud.pitch=bgspeed = bg.speed = 0;
        this.enabled = false;
        ShowExplosion(true);      //顯示爆炸
    }
    public void BoomEnd ()     //發生爆炸的尾端
    {
        Debug.Log("爆炸結束");
        this.enabled = true;   //打開這個腳本
        ShowExplosion(false);   //隱藏爆炸
    }

    void ShowExplosion(bool show)
    {
        Explosion.SetActive(show);    //隱藏爆炸特效的物件
        GetComponent<SpriteRenderer>().enabled = !show;
        GetComponent<BoxCollider2D>().enabled = !show;
    }

    public void Stop()     //遊戲停止
    {
        aud.pitch=bg.speed = bgspeed = 0; 
        this.enabled = false;
        PlayerDateManager.self.data.Stop = true;   //遊戲停止
        MenuCtl.self.ShowResult();    //顯示選單
    }

    private void OnTriggerEnter2D(Collider2D collider)   //無形碰撞框
    {
        if (collider.tag == "enemy")
        {
            //BoomStart();  //發生爆炸
            GetComponent<CarRotateCtl>().Hit(transform.position.x - DefaultPosX >= 0 ? 1:-1);
            IsHit = true;
            MenuCtl.self.HitNum++;
            // Destroy(collider.gameObject);  //拖敵人下水
        }

        else if (collider.tag == "Bomb")
        {
            BoomStart();  //發生爆炸
            MenuCtl.self.HitNum++;
            Destroy(collider.gameObject);  //炸彈不見
        }
        
        else if (collider.tag == "Fuel")
        {       
            Fuelctl.self.GetFuel();   //加油
            Destroy(collider.gameObject);  //油桶不見
        }
    }

}

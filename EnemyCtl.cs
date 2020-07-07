using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//控制敵人移動
public class EnemyCtl : MonoBehaviour           
{
    public int Type;        //敵人種類

    private float speed = 0.8f;
    private float MaxDistance = 13f;
    private float XMoveDistance = 8f;
    private float Duration = 1f;
    private bool IsMove = false;
    private Vector2 xmoverange = new Vector2(-3.7f, 1.3f);  //車左右(x軸)移動範圍
    //private const string BombPrefabPath = "Prefabs/Bomb";   //地雷的prefab路徑
    void FixedUpdate()
    {
        float TrueSpeed = speed - carctl.self.bgspeed;       //算出敵人真正該移動的速度
        transform.position += new Vector3(0, TrueSpeed, 0);
        /*   自己做的行為模式
        if (SpawnEnemyCtl.self.ID == 0)   黃車會打滑
            SpawnEnemyCtl.self.enemy.transform.Rotate(new Vector3 (0,0,10f));
        if (SpawnEnemyCtl.self.ID == 2)  紅車偏移特快
        {
            if (!IsMove && Vector3.Distance(transform.position, carctl.self.transform.position) < XMoveDistance)
            {
                transform.DOMoveX(carctl.self.transform.position.x, Duration*0.5f);
                IsMove = true;
            }        


            Vector3 myPos = new Vector3(0, transform.position.y, transform.position.z);
            Vector3 Pos2 = new Vector3(0, SpawnEnemyCtl.self.enemy.transform.position.y, SpawnEnemyCtl.self.enemy.transform.position.z);
            if (Vector3.Distance(myPos, Pos2) < 4f)
            {
               
            }    
        }  */
            //若這個物件位置 和 敵人產生器位置 距離超過 特定距離
            if (Vector3.Distance(transform.position, SpawnEnemyCtl.self.transform.position) > MaxDistance)
            Destroy(gameObject);

        XMove();
    }

    void XMove()
    {
        if(Type==0)   //衝撞玩家
        {
            HitPlayer();
        }
        else if(Type==1)   //x軸不動
        {

        }
        else if(Type==2)  //x軸固定來回
        {
            Type2();
        }
    }
    void HitPlayer()
    {
        //若敵人沒移動過 且 這個物件位置 和 玩家汽車位置 距離小於 特定距離
        if (!IsMove && Vector3.Distance(transform.position, carctl.self.transform.position) < XMoveDistance)
        {
            if (Mathf.Abs(transform.position.x - carctl.self.transform.position.x) > 1.5f)
                EffectPlayer.self.PlayEffect("EnemyMove");
            transform.DOMoveX(carctl.self.transform.position.x, Duration);
            IsMove = true;
        }
    }
    void Type2()
    {
        if(!IsMove)
        {
            float Left = transform.position.x - 1.5f;
            Left = Mathf.Clamp(Left, xmoverange.x, xmoverange.y);
            float Right = transform.position.x + 1.5f;
            Right = Mathf.Clamp(Right, xmoverange.x, xmoverange.y);
            
            int Ran = Random.Range(0, 2);
            if(Ran==0)
            {
                transform.DOMoveX(Right, 0);
                PingPong(Left,Right);
            }
            else
            {
                transform.DOMoveX(Left, 0);
                PingPong(Right, Left);
            }
            IsMove = true;
        
        }
    }  //敵人固定來回移動
    void PingPong(float left,float right)
    {
        //OnComplete 做完後接著做 
        transform.DOMoveX(left, Duration).SetEase(Ease.Linear).OnComplete(()=>PingPong(right,left));
    }    //主要來回移動的指令

}

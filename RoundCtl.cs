using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoundCtl : MonoBehaviour
{
    public int maxround;                //最大圈數
    public static RoundCtl self;
    private void Awake()
    {
        self = this;
    }

    private int round = 0;
    private int SpawnFuelRound;  //生產汽油的圈數
    private Vector2 SpawnFuelRange = new Vector2(3, 10);  //每3~10圈汽油生產
    private int SpawnBombRound;
    private Vector2 SpawnBombRange = new Vector2(3, 10);  //每3~10圈bomb生產

    public GameObject EndLine;

    private void Start()
    {
        SpawnFuelRound = round + Random.Range((int)SpawnFuelRange.x, (int)SpawnFuelRange.y);
        SpawnBombRound = round + (int)SpawnBombRange.x + (int)(SpawnBombRange.y * Random.value);

        Debug.Log(SpawnFuelRound + "" + SpawnBombRound);
        int level = Mathf.Clamp(PlayerDateManager.self.data.Level, 0, 2);
        maxround = LevelCtl.self.Round[level];
    }
    void RoadStart()
    {
        EndLine.SetActive(round >= maxround - 1); //(此為bool)在終點前一圈顯示終點線
    }
    
    void RoadEnd()
    {
        round++;
        if(round> SpawnFuelRound)
        {
            SpawnFuelCtl.self.Spawn();  //生產汽油
            //重新決定生產汽油的圈數
            SpawnFuelRound = round + Random.Range((int)SpawnFuelRange.x, (int)SpawnFuelRange.y);
            
        }
        if(round > SpawnBombRound)
        {
            SpawnBombCtl.self.Spawn();  //生產bomb
            //重新決定生產bomb的圈數
            SpawnBombRound = round + Random.Range((int)SpawnBombRange.x, (int)SpawnBombRange.y);
        }
        MapCtl.self.MapMove();
        if(round>=maxround)       //已行駛最大圈數
        {
            EffectPlayer.self.PlayEffect("Victory");
            carctl.self.Stop();   //過關
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotateCtl : MonoBehaviour
{
    private float CutSpeed = 0.015f;
    private float RotateSpeed = 20f;
    private float xmovespeed = 0.05f;  //打滑時車左右移動速度
    private int Direction;
    private void Awake()
    {
        this.enabled = false;
    }
    private void FixedUpdate()
    {
        carctl.self.bgspeed=Mathf.Clamp( carctl.self.bgspeed -= CutSpeed,0,1);
        transform.Rotate(0, 0, RotateSpeed*Direction);
        carctl.self.carposx -= xmovespeed*Direction;

    }
    public void Hit(int dir)
    {
        this.enabled = true;
        Direction = dir;
    }
}

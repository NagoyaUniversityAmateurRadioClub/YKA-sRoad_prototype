﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class system : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class Parameters//定数をまとめておくクラス
{
    private static float car_acceleration;//車の加速度の定数
    private static float back_acceleration;//ブレーキ加速度
    private static float car_forwardlimit;//車の前進速度限界
    private static float car_backspeedlimit;//車の後退速度限界
    private static float gravity;//重力加速度
    private static float natural_brake;//自然減速
    private static float raughroad_rate;//道を外れたときの加速、速度制限
    private static float rotation_rate;//ハンドル調整

    /*
    GameObject obj = new GameObject("Plain");
    road get = obj.AddComponent<road>;*/

    public Parameters()
    {
        car_acceleration = 0.1F;
        back_acceleration = 0.3F;
        car_forwardlimit = 50.0F;
        car_backspeedlimit = -5.0F;
        gravity = 20.0F;
        natural_brake = 0.05F;
        raughroad_rate = 0.7F;
        rotation_rate = 1.5F;
    }

    public float Get_acceleration()
    {
        return car_acceleration;
    }

    public float Get_brake()
    {
        return back_acceleration;
    }

    public float Get_forwardlimit()
    {
        return car_forwardlimit;
    }

    public float Get_gravity()
    {
        return gravity;
    }

    public float Get_natural_brake()
    {
        return natural_brake;
    }

    public float Get_raughroad_rate()
    {
        return raughroad_rate;
    }

    public float Get_rotation_rate()
    {
        return rotation_rate;
    }
}

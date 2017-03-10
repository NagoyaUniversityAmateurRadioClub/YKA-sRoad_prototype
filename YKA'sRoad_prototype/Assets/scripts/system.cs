using System.Collections;
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

public class parameters//定数をまとめておくクラス
{
    private static float car_acceleration;//車の加速度の定数
    private static float car_backspeedlimit;//車の後退速度限界
    private static float gravity;//重力加速度
    private static float natural_brake;//自然減速

    public parameters()
    {
        car_acceleration = 5.0F;
        car_backspeedlimit = 5.0F;
        gravity = 20.0F;
        natural_brake = 0.03F;
    }

    public float Get_acceleration()
    {
        return car_acceleration;
    }

    public float Get_gravity()
    {
        return gravity;
    }

    public float Get_natural_brake()
    {
        return natural_brake;
    }
}

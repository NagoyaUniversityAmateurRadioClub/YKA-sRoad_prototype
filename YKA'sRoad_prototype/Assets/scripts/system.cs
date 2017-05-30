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
    private static float slip_speed;//膨らむ速度
    /*
    GameObject obj = new GameObject("Plain");
    road get = obj.AddComponent<road>;*/

    public Parameters()
    {
        car_acceleration = 5.0F;
        back_acceleration = 15.0F;
        car_forwardlimit = 50.0F;
        car_backspeedlimit = -5.0F;
        gravity = 20.0F;
        natural_brake = 1.0F;
        raughroad_rate = 0.5F;
        rotation_rate = 5.0F;
        slip_speed = 25.0F;
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

    public float Get_rotation_rate(float speed)
    {
        float i = 1F;
        if(speed>slip_speed)
        {
            i = 2F;
        }
        return rotation_rate/i;
    }
}

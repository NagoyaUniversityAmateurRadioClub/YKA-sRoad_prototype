using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class system : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }

    

    // Update is called once per frame
    void Update ()
    {
    }
}


public class Parameters//定数をまとめておくクラス
{
    private static float easy;//調整値
    private static float car_acceleration;//車の加速度の定数
    private static float back_acceleration;//ブレーキ加速度
    private static float car_forwardlimit;//車の前進速度限界
    private static float car_backspeedlimit;//車の後退速度限界
    private static float gravity;//重力加速度
    private static float natural_brake;//自然減速
    private static float raughroad_rate;//道を外れたときの加速、速度制限
    private static float rotation_rate;//ハンドル調整
    private static float slip_speed;//膨らむ速度
    private static float curb_speed;//曲がりやすい速度
    private static float curb_rate;

    public Parameters()
    {
        easy = 0F;
        car_acceleration = 4.0F;
        back_acceleration = 15.0F;
        car_forwardlimit = 30.0F;
        car_backspeedlimit = -5.0F;
        gravity = 20.0F;
        natural_brake = 0.7F;
        raughroad_rate = 0.2F;
        rotation_rate = 5.0F;
        slip_speed = 20.0F+easy;
        curb_speed = 8.5F+easy;
        curb_rate = 0.6F;
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

    public float Get_backlimit()
    {
        return car_backspeedlimit;
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
        if(speed<curb_speed)
        {
            i = 0.5F;
        }
        if(speed>slip_speed)
        {
            i = 2F;
        }
        return rotation_rate/i;
    }

    public float Get_turn_rate()
    {
        return curb_rate;
    }
}

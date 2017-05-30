using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_move : MonoBehaviour
{
    private Parameters parameter = new Parameters();//sistemクラスのパラメーターを使うためのオブジェクト
    private Vector3 moveDirection = Vector3.zero;
    private float speed;//車のスピード
    private float road_rate;//道による加速、速度倍率
    private float f_limit;//前進速度限界
    private float b_limit;
    // Use this for initialization
    void Start()
    {
        speed = 0;
        road_rate = parameter.Get_raughroad_rate();
        f_limit = parameter.Get_forwardlimit();
        b_limit = parameter.Get_backlimit();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();//1ここから
        if (controller.isGrounded)
        {
            if (Input.GetAxis("Vertical") * speed >= 0)
            {
                speed += Input.GetAxis("Vertical") * parameter.Get_acceleration() * road_rate*Time.deltaTime;//ボタンを押す間加速度を速度に追加
            }
            else
            {
                speed += Input.GetAxis("Vertical") * parameter.Get_brake() * road_rate * Time.deltaTime;
            }
            moveDirection.x = speed * transform.forward.x * road_rate;
            moveDirection.z = speed * transform.forward.z * road_rate;//上の行と併せて車の向いている方向に移動距離を追加
            if (speed > 0)
            {
                speed -= parameter.Get_natural_brake() * Time.deltaTime;//速度がプラスなら減速
            }
            else if (speed < 0)
            {
                speed += parameter.Get_natural_brake() * Time.deltaTime;//速度がマイナスなら加速
            }

            if(speed>f_limit*road_rate)
            {
                speed = f_limit * road_rate;
            }

            if (speed < b_limit * road_rate)
            {
                speed = b_limit * road_rate;
            }

            transform.Rotate(0, Input.GetAxis("Horizontal") * parameter.Get_rotation_rate(speed) * speed * Time.deltaTime, 0);
        }
        moveDirection.y -= parameter.Get_gravity() * Time.deltaTime * Time.deltaTime;//重力による落下処理
        controller.Move(moveDirection * Time.deltaTime);//1ここまでが車の動作処理
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "road")
        {
            road_rate = 1.0F;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "road")
        {
            road_rate = parameter.Get_raughroad_rate();
        }
    }
}

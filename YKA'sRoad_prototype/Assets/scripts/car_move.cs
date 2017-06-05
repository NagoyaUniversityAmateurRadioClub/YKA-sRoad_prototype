using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class car_move : MonoBehaviour
{
    private Parameters parameter = new Parameters();//sistemクラスのパラメーターを使うためのオブジェクト
    private Vector3 moveDirection = Vector3.zero;
    private float speed;//車のスピード
    private float road_rate;//道による加速、速度倍率
    private float turn_rate;
    private float f_limit;//前進速度限界
    private float b_limit;
    private float stime;
    private float gtime;
    public static float rtime;
    public Text tx_speed;
    public Text tx_main;
    public Text tx_time;
    private bool is_goal;
    private bool is_flag1;
    private bool is_flag2;
    private bool is_flag3;
    private int swi;
    // Use this for initialization
    void Start()
    {
        speed = 0;
        swi = 0;
        road_rate = parameter.Get_raughroad_rate();
        turn_rate = 1.0F;
        f_limit = parameter.Get_forwardlimit();
        b_limit = parameter.Get_backlimit();
        is_goal = false;
        is_flag1 = false;
        is_flag2 = false;
        is_flag3 = false;
        tx_main.text = "それでは\nスタートです";
        Invoke("tx3", 3.0F);
        Invoke("tx2", 4.0F);
        Invoke("tx1", 5.0F);
        Invoke("txst", 6.0F);
        Invoke("txcl", 7.0F);
    }

    void tx3()
    {
        tx_main.text = "3";
    }

    void tx2()
    {
        tx_main.text = "2";
    }

    void tx1()
    {
        tx_main.text = "1";
    }

    void txst()
    {
        stime = Time.realtimeSinceStartup;
        tx_main.text = "start!!";
        swi = 1;
    }

    void txcl()
    {
        tx_main.text = "";
    }


    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();//1ここから
        if (controller.isGrounded)
        {
            if (Input.GetAxis("Vertical") * speed >= 0)
            {
                speed += Input.GetAxis("Vertical") * parameter.Get_acceleration() * road_rate*Time.deltaTime * swi;//ボタンを押す間加速度を速度に追加
            }
            else
            {
                speed += Input.GetAxis("Vertical") * parameter.Get_brake() * road_rate * Time.deltaTime * swi;
            }
            moveDirection.x = speed * transform.forward.x;
            moveDirection.z = speed * transform.forward.z;//上の行と併せて車の向いている方向に移動距離を追加
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

            transform.Rotate(0, Input.GetAxis("Horizontal") * parameter.Get_rotation_rate(speed)*turn_rate * speed* Time.deltaTime *swi, 0);
        }
        moveDirection.y -= parameter.Get_gravity() * Time.deltaTime * Time.deltaTime;//重力による落下処理
        controller.Move(moveDirection * Time.deltaTime);//1ここまでが車の動作処理

        gtime = Time.realtimeSinceStartup - stime;

        if (swi > 0)
        {
            if (is_goal)
            {
                rtime = gtime;
                is_goal = false;
                tx_main.text = "goal!!!\n\nyour time\n" + rtime.ToString();
                tx_time.text = "";
                Invoke("end_toScene", 4.0F);
                swi = 0;
            }

            if (gtime > 300)
            {
                tx_main.text = "Time over!!";
                Invoke("end_toScene", 4.0F);
                swi = 0;
                rtime = 300;
            }
        }

        tx_time.text = (gtime * swi).ToString();//ここからUI
        tx_speed.text = speed.ToString();
        tx_speed.text = "";

        
    }

    public static float Get_thisScore()
    {
        return rtime;
    }

    void end_toScene()
    {
        SceneManager.LoadScene("end");
    }

    void OnTriggerEnter(Collider line)
    {
        if(line.gameObject.tag=="point1")
        {
            is_flag1 = true;
        }
        
        if((line.gameObject.tag =="point2")&&is_flag1)
        {
            is_flag2 = true;
        }

        if ((line.gameObject.tag == "point3") && is_flag2)
        {
            is_flag3 = true;
        }

        if ((line.gameObject.tag == "goal") && is_flag3)
        {
            is_goal = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "road")
        {
            road_rate = 1.0F;
            turn_rate = 1.0F;
        }
        
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "road")
        {
            road_rate = parameter.Get_raughroad_rate();
            turn_rate = parameter.Get_turn_rate();
        }
    }
}

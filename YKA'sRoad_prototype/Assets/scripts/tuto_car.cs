using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tuto_car : MonoBehaviour
{
    private Parameters parameter = new Parameters();//sistemクラスのパラメーターを使うためのオブジェクト
    private Vector3 moveDirection = Vector3.zero;
    private float speed;//車のスピード
    private float tmp_speed;//スピード保存
    private float road_rate;//道による加速、速度倍率
    private float turn_rate;
    private float f_limit;//前進速度限界
    private float b_limit;
    private float stime;
    public Text tx_tmain;
    public Text tx_ctime;
    public bool is_goal;
    private bool is_swflag;
    private bool is_flag1;
    private bool is_flag2;
    private bool is_flag3;
    private bool is_gflag;
    private bool is_allflag;
    private int swi;
    // Use this for initialization
    void Start()
    {
        speed = 0;
        swi = 0;
        road_rate = parameter.Get_raughroad_rate();
        f_limit = parameter.Get_forwardlimit();
        b_limit = parameter.Get_backlimit();
        is_swflag = true;
        is_goal = false;
        is_flag1 = false;
        is_flag2 = false;
        is_flag3 = false;
        is_gflag = false;
        is_allflag = true;
        tx_tmain.text = "YKA's Road へようこそ";
        tx_ctime.text = "";
        Invoke("tx3", 3.0F);
        Invoke("tx2", 3.0F);
        Invoke("tx1", 8.0F);
        Invoke("txcls", 11.0F);
    }

    void tx3()
    {
        tx_tmain.text = "これよりチュートリアルを始めます";
    }

    void tx2()
    {
        tx_tmain.text = "右手のボタンを押すと加速します";
    }

    void tx1()
    {
        tx_tmain.text = "加速してください";
    }



    void txcls()
    {
        speed = tmp_speed;
        swi = 1;
        tx_tmain.text = "";

    }


    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();//1ここから
        if (controller.isGrounded)
        {
            if (Input.GetAxis("Vertical") * speed >= 0)
            {
                speed += Input.GetAxis("Vertical") * parameter.Get_acceleration() * road_rate * Time.deltaTime * swi;//ボタンを押す間加速度を速度に追加
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

            if (speed > f_limit * road_rate)
            {
                speed = f_limit * road_rate;
            }

            if (speed < b_limit * road_rate)
            {
                speed = b_limit * road_rate;
            }

            transform.Rotate(0, Input.GetAxis("Horizontal") * parameter.Get_rotation_rate(speed) * speed * Time.deltaTime * swi, 0);
        }
        moveDirection.y -= parameter.Get_gravity() * Time.deltaTime * Time.deltaTime;//重力による落下処理
        controller.Move(moveDirection * Time.deltaTime);//1ここまでが車の動作処理



        if(is_flag1&&(speed<-4.9)&&(!is_swflag)&&is_allflag)
        {
            is_swflag = true;
            swi = 0;
            tx_tmain.text = "OKです\nそれではもう一度加速してください";
            tmp_speed = speed;
            speed = 0;
            Invoke("txcls", 3.0F);
        }

        if (is_goal)
        {
            is_goal = false;
            stime = Time.realtimeSinceStartup;
            is_gflag = true;
        }

        if (is_gflag)
        {
            tx_ctime.text = (40F + stime - Time.realtimeSinceStartup).ToString();
            if (Time.realtimeSinceStartup > stime + 40F)
            {
                SceneManager.LoadScene("main");
            }
        }
    }

    void OnTriggerEnter(Collider line)
    {
        if (line.gameObject.tag == "point1")
        {
            if (is_swflag)
            {
                is_swflag = false;
                is_flag1 = true;
                tmp_speed = speed;
                speed = 0;
                swi = 0;
                tx_tmain.text = "左手のボタンを押すと減速\nそのまま押し続けるとバックします\nバックしてください";
                Invoke("txcls", 5.0F);
            }
        }

        if ((line.gameObject.tag == "point2") && is_flag1&&is_swflag)
        {
            is_flag1 = false;
            is_flag2 = true;
            is_swflag = false;
            swi = 0;
            tmp_speed = speed;
            speed = 0;
            tx_tmain.text = "次はカーブです\n右に曲がるにはR、左にはLを押します";
            Invoke("txcurb1", 4.0F);
            Invoke("txcls", 8.0F);
        }

        if ((line.gameObject.tag == "point3") && is_flag2&&(!is_swflag))
        {
            is_flag3 = true;
            swi = 0;
            tmp_speed = speed;
            speed = 0;
            tx_tmain.text = "道から外れると大きくスピードが落ちます\nこのまま進んで確認してください";
            Invoke("txcls", 5.0F);
        }

        if ((line.gameObject.tag == "goal") && is_flag3)
        {
            is_goal = true;
            swi = 0;
            tmp_speed = speed;
            speed = 0;
            tx_tmain.text = "これでチュートリアルは終了です\nレースでは300秒の時間制限があるので気をつけてください";
            Invoke("txgo", 5.0F);
            Invoke("txcls", 10.0F);
        }
    }

    void txcurb1()
    {
        tx_tmain.text = "曲がる前には必ず減速してください\nただしスピードが0の時は曲がれません";
    }

    void txgo()
    {
        tx_tmain.text = "30秒後にレーススタートです\nそれまでは自由に走ってください";
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

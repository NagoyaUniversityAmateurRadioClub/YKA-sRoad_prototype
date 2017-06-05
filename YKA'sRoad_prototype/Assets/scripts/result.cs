using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Text;

public class Tmp
{
    static string filename;
    public static string path;

    public Tmp()
    {
        path = "test.txt";
    }

    public string Get_path()
    {
        return path;
    }

}

public class result : MonoBehaviour {

    public Text tx_scores;
    public Text tx_thisScore;
    public Text tx_message;
    Tmp ptmp = new Tmp();
    private string path;
    private bool is_ok;
    public float[] scores = new float[5];
    private float thisScore;
    private float tmp;
    int i;
	// Use this for initialization
	void Start () {
        is_ok = false;
        path = ptmp.Get_path();
        tx_message.text = "";
        thisScore = car_move.Get_thisScore();
        for(i=0;i<5;i++)
        {
            scores[i] = setup.rb_times[i];
        }

        ReadFile();
        if(thisScore<scores[4])
        {
            scores[4] = thisScore;
        }
        for (i = 4; i > 0; i--)
        {
            if(scores[i-1]>scores[i])
            {
                tmp = scores[i - 1];
                scores[i - 1] = scores[i];
                scores[i] = tmp;
            }
        }

        tx_thisScore.text = "your score\n" + thisScore.ToString();
        tx_scores.text = "1: " + scores[0].ToString() + "\n2: " + scores[1].ToString() + "\n3: " + scores[2].ToString() + "\n4: " + scores[3].ToString() + "\n5: " + scores[4].ToString();

        Invoke("txpop", 5.0F);
    }
	
    void txpop()
    {
        tx_message.text = "push any key";
        is_ok = true;
    }

	// Update is called once per frame
	void Update () {
        if (is_ok)
        {
            if (Input.anyKeyDown)
            {
                writeFile();
                SceneManager.LoadScene("title");
            }

            tx_message.color = new Color(238, 255, 0, Mathf.PingPong(Time.time, 1));
        }
	}

    void ReadFile()
    {
        string buf;
        StreamReader sr = new StreamReader(path, Encoding.Unicode);
        buf = sr.ReadToEnd();
        string[] array = buf.Split(':');
        for (i = 0; i < 5; i++)
        {
            scores[i] = float.Parse(array[i]);
        }

        sr.Close();
    }

    void writeFile()
    {
        string buf = scores[0].ToString() + ":" + scores[1].ToString() + ":" + scores[2].ToString() + ":" + scores[3].ToString() + ":" + scores[4].ToString();
        StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("Unicode"));
        sw.WriteLine(buf);
        sw.Close();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Text;


public class setup : MonoBehaviour
{

    public static float[] rb_times = new float[5];
    Tmp tmp = new Tmp();
    int i;
    

	// Use this for initialization
	void Start ()
    {
        ReadFile();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("title");
        }
		
	}

    public void ReadFile()
    {
        string path = tmp.Get_path();
        try
        {
            string buf;           
            StreamReader sr = new StreamReader(path, Encoding.Unicode);
            buf = sr.ReadToEnd();
            string[] array = buf.Split(':');
            for(i=0;i<5;i++)
            {
                rb_times[i] = float.Parse(array[i]);
            }

            sr.Close();

        }
        catch(FileNotFoundException)
        {
            string buf ="100:150:200:250:300";
            StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("Unicode"));
            sw.WriteLine(buf);
            sw.Close();
        }

    }

}

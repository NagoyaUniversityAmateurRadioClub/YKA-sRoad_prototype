using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Text;

public class setup  {

    public float[] rb_times = new float[5];
    int i;
    string folder = Application.dataPath;
    string filename = "test.txt";

	// Use this for initialization
	void Start ()
    {

        for (i = 0; i < 5; i++)
        {
            rb_times[i] = 0F;
        }

        ReadFile(folder,filename);
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("title");
        }
		
	}

    public void ReadFile(string folder,string filename)
    {

    }
}

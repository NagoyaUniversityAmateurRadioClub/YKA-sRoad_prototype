using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class title_control : MonoBehaviour {

    public Text blinkText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.anyKeyDown)
        {
            Application.LoadLevel("main");
        }

        blinkText.color = new Color(238, 255, 0, Mathf.PingPong(Time.time, 1));
	}
}

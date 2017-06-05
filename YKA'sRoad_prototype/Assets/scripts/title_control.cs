using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class title_control : MonoBehaviour {

    public Text blinkText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("setup");
        }

        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene("tutorial");
        }

        blinkText.color = new Color(238, 255, 0, Mathf.PingPong(Time.time, 1));
	}
}

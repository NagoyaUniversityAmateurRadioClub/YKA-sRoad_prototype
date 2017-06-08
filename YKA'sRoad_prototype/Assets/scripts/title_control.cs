using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class title_control : MonoBehaviour {

    public Text blinkText;
    AudioSource aud;
	// Use this for initialization
	void Start () {
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("setup");
        }

        if(Input.anyKeyDown)
        {
            aud.Play();
            SteamVR.instance.hmd.ResetSeatedZeroPose();
            Invoke("Ltuto", 1.0F);
        }

        blinkText.color = new Color(238, 255, 0, Mathf.PingPong(Time.time, 1));
	}

    void Ltuto()
    {
        SceneManager.LoadScene("tutorial");
    }
}

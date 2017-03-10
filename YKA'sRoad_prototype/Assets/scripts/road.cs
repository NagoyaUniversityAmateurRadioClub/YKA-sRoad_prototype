using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road : MonoBehaviour {
    private bool frag_road;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            frag_road = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            frag_road = false;
        }
    }

    bool Get_frag_road()
    {
        return frag_road;
    }
}

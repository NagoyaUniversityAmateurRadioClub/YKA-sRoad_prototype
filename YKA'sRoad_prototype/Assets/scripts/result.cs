using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour {

    public Text tx_scores;
    public Text tx_thisScore;
    private float thisScore;
	// Use this for initialization
	void Start () {
        thisScore = car_move.Get_thisScore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

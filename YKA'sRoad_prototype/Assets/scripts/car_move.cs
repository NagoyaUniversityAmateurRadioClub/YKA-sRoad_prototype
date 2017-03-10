using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_move : MonoBehaviour {
    private parameters parameter = new parameters();
    private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CharacterController controller = GetComponent<CharacterController>();

        moveDirection.z += Input.GetAxis("Vertical") * parameter.Get_acceleration() * Time.deltaTime;
        moveDirection.y -= parameter.Get_gravity() * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        if(moveDirection.z>0)
        {
            moveDirection.z -= parameter.Get_natural_brake();
        }else
            if (moveDirection.z < 0)
        {
            moveDirection.z += parameter.Get_natural_brake();
        }
	}
}

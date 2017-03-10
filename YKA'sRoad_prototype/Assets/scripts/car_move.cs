using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_move : MonoBehaviour {
    private parameters parameter = new parameters();
    private Vector3 moveDirection = Vector3.zero;
    private float speed;

	// Use this for initialization
	void Start () {
        speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            speed += Input.GetAxis("Vertical") * parameter.Get_acceleration();
            moveDirection.x = speed * transform.forward.x /* Time.deltaTime*/;
            moveDirection.z = speed * transform.forward.z /* Time.deltaTime*/;
            if (speed > 0)
            {
                speed -= parameter.Get_natural_brake();
            }
            else if (speed < 0)
            {
                speed += parameter.Get_natural_brake();
            }
            transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        }
        moveDirection.y -= parameter.Get_gravity() * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	}
}

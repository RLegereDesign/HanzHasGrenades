using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody rb;

    public float speed;



	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {




        if (Input.GetAxis("LeftJoystickX") < 0)
        {
            rb.rotation = Quaternion.Euler (0.0f, -90.0f, 0.0f);
            //rb.velocity = transform.forward * speed;
        } else if (Input.GetAxis("LeftJoystickX") > 0) {

            rb.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
          //  rb.velocity = transform.forward * speed;

        }
        else if (Input.GetAxis("LeftJoystickY") > 0)
        {

            rb.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
           // rb.velocity = transform.forward * speed;

        }
        else if (Input.GetAxis("LeftJoystickY") < 0)
        {

            rb.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
          //  rb.velocity = transform.forward * speed;

        }


        if (Input.GetButton("LeftJoystickX") || Input.GetButton("LeftStickY"))
        {
            rb.velocity = transform.forward * speed;
        }

    }
}

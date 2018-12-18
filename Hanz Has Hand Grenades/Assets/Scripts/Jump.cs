using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    private CharacterController characterController;
    private CharacterController characterController2;

    public float jumpForce;
    private Vector3 movementVector;
    public GameObject player;

    public int sticknum;
    public Camera cam;
    private Vector3 camie;

    public GameObject enemy;

    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public GameObject Groundo;
    private float count = 0;
    public float jumpTime;
    private bool grounded = false;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        count = jumpTime;
        characterController = player.GetComponent<CharacterController>();
        characterController2 = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (grounded == true && anim.GetBool("Jumping") == true)
        {
            anim.SetBool("Jumping", false);
        }

        string stickstring = sticknum.ToString();



        if (Input.GetButtonDown("AP" + stickstring) && grounded == true && Input.GetAxis("LeftTrig" + stickstring) == 0)
        {
            anim.SetBool("Jumping", true);
            grounded = false;
            moveDirection.y = jumpSpeed;
            characterController.Move(moveDirection * Time.deltaTime);

            count = jumpTime;
        }

        if(count > 0)
        {
            count -= (Time.deltaTime * 55);
        }

        if (count < 0)
        {
            count = 0;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);


        movementVector = new Vector3(Input.GetAxis("LeftJoystickX" + stickstring), 0f, Input.GetAxis("LeftJoystickY" + stickstring));

        movementVector = cam.transform.TransformDirection(movementVector);

        camie = cam.transform.forward;
        camie.y = 0.0f;

        movementVector.y = 0.0f;
        // movementVector.z = 0.0f;

        /* if (Input.GetAxis("LeftJoystickX" + stickstring) != 0 || Input.GetAxis("LeftJoystickY" + stickstring) != 0)
         {
             gameObject.transform.rotation = new Quaternion(0.0f, movementVector.y, 0.0f, 0.0f);
         } */

        if (anim.GetBool("Aiming") == true && Input.GetAxis("LeftJoystickX" + stickstring) == 0)
        {
            anim.SetBool("Aiming", false);
        }

        if (Input.GetAxis("LeftTrig" + stickstring) != 0)
        {
            if (anim.GetBool("Aiming") == false)
            {
                anim.SetBool("Aiming", true);
            }

            transform.forward = camie;
        }
        else if (Input.GetAxis("LeftJoystickX" + stickstring) != 0 || Input.GetAxis("LeftJoystickY" + stickstring) != 0) ;
        {
            if (Input.GetAxis("LeftTrig" + stickstring) == 0)
            {
                if (anim.GetBool("Running") == false)
                {
                    anim.SetBool("Running", true);
                }
                transform.forward = movementVector;
            }
        }

        

        if (Input.GetAxis("LeftJoystickX" + stickstring) == 0 && Input.GetAxis("LeftJoystickY" + stickstring) == 0 && Input.GetAxis("LeftTrig" + stickstring) == 0)
        {
            if (anim.GetBool("Running") == true)
            {
                anim.SetBool("Running", false);
            }
            transform.LookAt(enemy.transform);
        }

        //transform.forward = Vector3.Normalize(new Vector3(Input.GetAxis("LeftJoystickX" + stickstring), 0f, Input.GetAxis("LeftJoystickY" + stickstring)));
        //transform.forward = Vector3.Normalize(cam.transform);


        /* movementVector = cam.transform.TransformDirection(movementVector);

         movementVector.y = 0.0f;

         if (characterController2.isGrounded)

         {

            // movementVector.y = 0;

             if (Input.GetButtonDown("A"))
             {

               //  transform.position.y += jumpForce;

                 movementVector.y += jumpForce;



             }


         } */

        //  movementVector.y -= gravity * Time.deltaTime;

        //movementVector2.y -= gravity * Time.deltaTime;

        //characterController2.Move(movementVector * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(new Vector3(0.0f, movementVector.y, 0.0f));



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}

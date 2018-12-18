using UnityEngine;

using System.Collections;

public class PlayerController : MonoBehaviour

{

    private Vector3 movementVector;
    // private Vector3 movementVector2;


    private CharacterController characterController;
    //  public GameObject player;
    // private CharacterController charConPlay;


    // public Camera Cam;

    public float movementSpeed = 8;

    public float jumpPower = 15;

    public float gravity = 40;

    public int stickNumber;

    public Camera cam;

    void Start()

    {

        characterController = GetComponent<CharacterController>();
        //charConPlay = player.GetComponent<CharacterController>();

    }

    void Update()

    {

        // Debug.Log(Input.GetAxis("RightJoystickY"));

        string stickstring = stickNumber.ToString();

        movementVector.x = Input.GetAxis("LeftJoystickX" + stickstring) * movementSpeed;

        movementVector.z = Input.GetAxis("LeftJoystickY" + stickstring) * movementSpeed;

        movementVector = cam.transform.TransformDirection(movementVector);
        movementVector.y = 0.0f;


        //  if (Input.GetAxis("LeftJoystickX") != 0|| Input.GetAxis("LeftJoystickY") != 0)
        // {
        //      gameObject.transform.rotation = new Quaternion(0.0f, CamSloot.transform.rotation.y, 0.0f, 0.0f);
        //  }

        //transform.forward = Vector3.Normalize(new Vector3(Input.GetAxis("LeftJoystickX"), 0f, -Input.GetAxis("LeftJoystickY")));

        /* if (characterController.isGrounded)

          {

              movementVector.y = 0;

              if (Input.GetButtonDown("A"))

              {

                 movementVector.y = jumpPower;

              }

          } */

        // movementVector.y -= gravity * Time.deltaTime;

        // movementVector2.y -= gravity * Time.deltaTime;

        if (Input.GetAxis("LeftTrig" + stickstring) == 0)
        {
            characterController.Move(new Vector3(movementVector.x * Time.deltaTime, 0.0f, movementVector.z * Time.deltaTime));
        }
        //charConPlay.Move(movementVector2 * Time.deltaTime);

    }

}
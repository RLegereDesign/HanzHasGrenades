using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{

    public GameObject grenadePrefab;
    public Transform grenadeSpawnPoint;

    public float fireRate;
    private float nextFire;
    public int stickNumber;

    private Animator anim;


    private void Start()
    {

        anim = GetComponent<Animator>();


    }



    // Update is called once per frame
    void Update()
    {



        string stickstring = stickNumber.ToString();


        //"Fire1" input (left mouse) used for shooting in base script... update for Xbox controls

        if (Input.GetAxis("LeftTrig" + stickNumber) != 0)
        {
            if (Input.GetAxis("RightTrig" + stickstring) != 0 && Time.time > nextFire)
            {
                anim.SetTrigger("Throw");

                nextFire = Time.time + fireRate;

                CmdFire();

            }
        }
    }

    void CmdFire()
    {

        //Instantiates grenade prefab at player "ThrowPoint" position & rotation
        var grenade = (GameObject)Instantiate(
            grenadePrefab,
            grenadeSpawnPoint.position,
            grenadeSpawnPoint.rotation);

    }
}

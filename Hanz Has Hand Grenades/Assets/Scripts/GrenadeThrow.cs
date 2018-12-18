using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrenadeThrow : MonoBehaviour
{

    public GameObject grenadePrefab;
    public GameObject impactPrefab;
    public GameObject megaPrefab;

    public Transform grenadeSpawnPoint;

    public float fireRate;
    private float nextFire;
    public int stickNumber;

    private Animator anim;

    public float points = 0;

    public TextMeshProUGUI PlayerPts;

    private bool Stick = true;
    private bool Impact = false;
    private bool Mega = false;



    private void Start()
    {

        anim = GetComponent<Animator>();


    }



    // Update is called once per frame
    void Update()
    {
        Debug.Log(Impact);
        PlayerPts.SetText( "Points: " + points.ToString() );

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


        if(Input.GetAxis("DP" + stickstring) < 0 && points > 1000)
        {
            points -= 1000;
            Impact = true;
            Stick = false;
            Mega = false;
        }

        if (Input.GetAxis("DP" + stickstring) > 0)
        {
            points -= 1100;
            Impact = false;
            Stick = false;
            Mega = true;
        }


    }

    void CmdFire()
    {

        //Instantiates grenade prefab at player "ThrowPoint" position & rotation

        if (Stick == true)
        {
            var grenade = (GameObject)Instantiate(
                grenadePrefab,
                grenadeSpawnPoint.position,
                grenadeSpawnPoint.rotation);
            
        }

        if (Impact == true)
        {
            var grenade = (GameObject)Instantiate(
                impactPrefab,
                grenadeSpawnPoint.position,
                grenadeSpawnPoint.rotation);
            Impact = false;
            Stick = true;
            
        }

        if (Mega == true)
        {
            var grenade = (GameObject)Instantiate(
                megaPrefab,
                grenadeSpawnPoint.position,
                grenadeSpawnPoint.rotation);
            Mega = false;
            Stick = true;
        }
    }
}

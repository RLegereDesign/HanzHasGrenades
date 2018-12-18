using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Health : MonoBehaviour {


    //Player health
    public float playerHealth;
    public GameObject player;
    public GameObject Win;
    public TextMeshProUGUI health;
    public Image p1HealthBarFill;
    private bool fuckedUp = false;
    public GameObject DeathCam;




    void Start()
    {
    //  playerHealth = 30;

        Win.gameObject.SetActive(false);
        player.SetActive(true);


    }


    void Update()
    {

        health.SetText("Health: " + playerHealth);
        p1HealthBarFill.fillAmount = ((playerHealth) / 100);


        if (playerHealth <= 0)
        {
            //health.SetText("Deceased");
            DeathCam.SetActive(true);
            Win.gameObject.SetActive(true);
            player.SetActive(false);
            health.gameObject.SetActive(false);


        }
        else
        {
            health.SetText("Health: " + playerHealth);

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spikes")
        {
            health.SetText("Deceased");

            Win.gameObject.SetActive(true);
            player.SetActive(false);
        }
        if (other.gameObject.tag == "BarbedWire" && fuckedUp == false)
        {
            TakeDamage(.5f);
            fuckedUp = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BarbedWire" && fuckedUp == true)
        {
            
            fuckedUp = false;

        }
    }

    /*    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "BarbedWire" && fuckedUp == false)
            {
                TakeDamage(20f);
                fuckedUp = true;

            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "BarbedWire" && fuckedUp == true)
            {
                TakeDamage(20f);
                fuckedUp = false;

            }
        } */



    //Player health
    public void TakeDamage(float amount)
    {

        playerHealth -= amount;

      //  Debug.Log(playerHealth);

       /* if(playerHealth == 90)
        {
            Debug.Log("90");
        }
        if (playerHealth == 60)
        {
            Debug.Log("60");
        }
        if (playerHealth == 30)
        {
            Debug.Log("30");
        }
        if (playerHealth == 0)
        {
            Debug.Log("0");
        } */

    }
}

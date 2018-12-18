using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHealth : MonoBehaviour
{

    public float health;
    private RaycastHit hit;
    public GameObject P1;
    public GameObject P2;
    public GameObject[] blood;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Physics.Raycast(transform.position, Vector3.up, out hit);
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void TakeDamage(float amount)
    {

        Physics.Raycast(transform.position, Vector3.up, out hit);
        if (Physics.Raycast(transform.position, Vector3.up, out hit) == null || hit.collider.gameObject.tag != "Ground")
        {
            health -= amount;
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grenade"))
        {
            TakeDamage(other.gameObject.GetComponent<GrenadeMove>().grenadeDamage);
            other.gameObject.GetComponent<GrenadeMove>().Score();

            foreach (GameObject blood in blood)
            {

                var hurt = (GameObject)Instantiate(blood, new Vector3(transform.position.x, transform.position.y, transform.position.z), Random.rotation);


            }

        }



       /* if (other.gameObject.CompareTag("GrenadeP2"))
        {
            TakeDamage(other.gameObject.GetComponent<GrenadeMove>().grenadeDamage);

            foreach (GameObject blood in blood)
            {

                var hurt = (GameObject)Instantiate(blood, new Vector3(transform.position.x, transform.position.y, transform.position.z), Random.rotation);


            }

        } */



        if (other.gameObject.CompareTag("Impact Grenade"))
        {

            //Debug.Log("IMPACT GRENADE HIT");

            TakeDamage(other.gameObject.GetComponent<ImpactGrenadeMove>().grenadeDamage);

            foreach (GameObject blood in blood)
            {

                var hurt = (GameObject)Instantiate(blood, new Vector3(transform.position.x, transform.position.y, transform.position.z), Random.rotation);


            }

        }

        if (other.gameObject.CompareTag("Mega Nade"))
        {

            //Debug.Log("MEGANADE HIT");

            TakeDamage(other.gameObject.GetComponent<MeganadeMove>().grenadeDamage);

            foreach (GameObject blood in blood)
            {

                var hurt = (GameObject)Instantiate(blood, new Vector3(transform.position.x, transform.position.y, transform.position.z), Random.rotation);


            }

        }


    }
}

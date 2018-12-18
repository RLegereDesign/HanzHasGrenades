using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactGrenadeMove : MonoBehaviour
{

    public float grenadeSpeed;

    public float countdown;

    //Creating explosion blast / range for detecting player hit & damage
    public float radius = 5.0f;
    public int grenadeDamage = 10;

    public GameObject player;
    public int EnemyNum;
    private Rigidbody rb;
    // public Camera cam;
    public string CamNumber;
    public Collider Boom;
    private Camera cam;
    private Animator animato;
    public GameObject explode;

    public GameObject[] blood;

    private bool hitter = false;

    void Start()
    {
        //animato = GetComponent<Animator>();

        string playNum = EnemyNum.ToString();
        cam = GameObject.Find("Camera" + CamNumber).GetComponent<Camera>();
        rb = GetComponent<Rigidbody>();

        //needed for getting player health from other script
        player = GameObject.Find("P" + EnemyNum);
        rb.AddForce(cam.transform.forward * grenadeSpeed);

        Collider[] Colliders = GetComponents<Collider>();
        foreach (Collider collider in Colliders)
        {
            if (collider.isTrigger)
            {
                Boom = collider;

            }
        }




    }

    void Update()
    {

    }




    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            rb.velocity = new Vector3(0f, 0f, 0f);

        }

        Boom.enabled = !Boom.enabled;
        explode.SetActive(true);
        //Debug.Log("WOW BOOM");

        StartCoroutine("Explosion");

        /*
        if (animato.enabled == true)
        {
            animato.enabled = !animato.enabled;

        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        string playNum = EnemyNum.ToString();

        if (other.gameObject.name == "P1" && hitter == false)
        {
            hitter = true;

            player.GetComponent<Health>().TakeDamage(grenadeDamage);



            foreach (GameObject blood in blood)
            {

                var hurt = (GameObject)Instantiate(blood, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z), Random.rotation);


            }



        }

        if (other.gameObject.name == "P2" && hitter == false)
        {
            hitter = true;
            player.GetComponent<HealthP2>().TakeDamage(grenadeDamage);

            foreach (GameObject blood in blood)
            {
                var hurt = (GameObject)Instantiate(blood, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z), Random.rotation);
            }

        }


    }



    IEnumerator Explosion()
    {

        //yield return new WaitForSeconds(countdown);

        // yield return new WaitForSeconds(1);

        yield return new WaitForSeconds(0.1f);

        //Debug.Log("WOW DESTROYED");
        Destroy(gameObject);
        yield return null;

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splatter : MonoBehaviour {

    private Rigidbody rb;
    public int speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * speed);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    IEnumerator Suicide()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}

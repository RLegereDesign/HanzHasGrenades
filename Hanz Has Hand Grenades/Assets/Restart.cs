using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
    public TextMeshProUGUI P1Win;
    public TextMeshProUGUI P2Win;
    public GameObject P1;
    public GameObject P2;

	// Use this for initialization
	void Start () {

        P1.SetActive(true);
        P2.SetActive(true);
		
	}
	
	// Update is called once per frame
	void Update () {

        if (P1Win.isActiveAndEnabled)
        {
            if (Input.GetButton("AP1"))
            {
                P1Win.gameObject.SetActive(false);
                P1.SetActive(true);

                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            }


            if (Input.GetButton("Cancel"))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        else if (P2Win.isActiveAndEnabled)
        {

            if (Input.GetButton("Cancel"))
            {
                SceneManager.LoadScene("MainMenu");
            }

            if (Input.GetButton("AP2"))
            {
                P2Win.gameObject.SetActive(false);
                P2.SetActive(true);
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            }
        }


		
	}
}

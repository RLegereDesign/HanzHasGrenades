using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject[] Wins;

    //Not sure if keeping game over scene/where it is in scene index list...
    //So get by name for now!

    public void Update()
    {
        if((Input.GetButton("AP1") || Input.GetButton("AP2")) && (Wins[0].activeSelf == true || Wins[1].activeSelf == true))
        {

            Replay();

        }


        if ((Input.GetButton("BP1") || Input.GetButton("BP2")) && (Wins[0].activeSelf == true || Wins[1].activeSelf == true))
        {

            MainMenu();

        }

    }



    public void Replay()
    {

        //want: scene index 1 -> level select, so +1
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("LevelSelect");

    }

    public void MainMenu()
    {

        //want: scene index 0 -> main menu, so -4
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        SceneManager.LoadScene("MainMenu");

    }
}

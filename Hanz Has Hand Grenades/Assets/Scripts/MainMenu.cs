using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //We are currently on scene index 0 -> main menu

	public void PlayGame() {

        //want: scene index 1 -> level select, so +1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("LevelSelect");

    }

    public void PlayCredits()
    {

        //want: scene index 4 -> credits, so +4
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        //SceneManager.LoadScene("Credits");

    }

    public void QuitGame() {

        Debug.Log("Quit!");
        Application.Quit();

	}
}

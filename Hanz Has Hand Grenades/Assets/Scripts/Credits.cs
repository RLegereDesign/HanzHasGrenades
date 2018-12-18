using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    //We are currently on scene index 5 -> credits

    public void Return()
    {

        //want: scene index 0 -> main menu, so -5
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
        //SceneManager.LoadScene("MainMenu");

    }
}

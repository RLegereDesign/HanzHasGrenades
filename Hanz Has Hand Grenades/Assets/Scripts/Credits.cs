using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    //We are currently on scene index 4 -> credits

    public void Return()
    {

        //want: scene index 0 -> main menu, so -4
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        //SceneManager.LoadScene("MainMenu");

    }
}

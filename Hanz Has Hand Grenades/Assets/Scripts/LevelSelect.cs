using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

    //We are currently on scene index 1 -> level select

    public void PlayLevel1 ()
    {

        //want: scene index 2 -> sample scene (level 1), so +1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("SampleScene");

    }

    public void PlayLevel2 ()
    {
        //want: scene index ?? will be 3 ?? -> sample scene 2 (level 2), so +2?
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        //SceneManager.LoadScene("SampleScene2");
    }

    public void PlayLevel3()
    {
        //want: scene index ?? will be 4 ?? -> sample scene 3 (level 3), so +3?
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        //SceneManager.LoadScene("SampleScene3");
    }

    public void Return()
    {

        //want: scene index 0 -> main menu, so -1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //SceneManager.LoadScene("MainMenu");


    }
}

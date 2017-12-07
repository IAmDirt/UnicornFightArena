using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenueButtons : MonoBehaviour {

    public void PlayeGame()
    {

        SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
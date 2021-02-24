using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool yes = true;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


    public void Load()
    {
        Debug.Log("Continue");
        Time.timeScale = 1f;
    }

    public void NewGame()
    {
        Debug.Log("NEWGame");
        Time.timeScale = 1f;
    }

    public bool menuActive()
    {
        return yes;
    }
}

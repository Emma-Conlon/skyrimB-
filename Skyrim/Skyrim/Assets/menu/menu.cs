using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Load()
    {

        
       //// PlayerSaveData data = SaveSystem.LoadPlayer();
        SceneManager.LoadScene("Skyrim");
        PlayerPrefs.GetInt("health");
        Time.timeScale = 1f;
        
    }

    public void newGame()
    {

        SceneManager.LoadScene("Skyrim");
        Time.timeScale = 1f;
    }

}


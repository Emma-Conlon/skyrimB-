using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    public bool yes = true;
    public PlayerController player;
    public GameObject pause;
    public GameObject MENU;
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
        PlayerSaveData data = SaveSystem.LoadPlayer();
        Debug.Log("Continue");
        pause.SetActive(false);
        Time.timeScale = 1f;
        player.pause = false;
    }

    public void newGame()
    {
      
        pause.SetActive(false);
    
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
        MENU.SetActive(false);
        Time.timeScale = 1f;
    }

    public bool menuActive()
    {
        return yes;
    }

    public void GameOver()
    {

    }
}

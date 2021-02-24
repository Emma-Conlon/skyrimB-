using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = true;
  
    public DayNight day;
    public GameObject pauseMenuUI;

    public PlayerController player;

    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(GameisPaused)
            {
                Resume();
                Debug.Log("PRESSED");

            }
            else
            {
                Pause();
                Debug.Log("MENU");
            }
        }
    }

   public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        player.canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        day.pause = false;
}

    void Pause()
    {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
        player.canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void LoadingMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MENU");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}

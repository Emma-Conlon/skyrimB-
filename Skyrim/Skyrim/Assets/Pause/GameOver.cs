using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{


    public static bool GameisOver = false;

    public GameObject gameOverUI;

    public PlayerController player;
    public DayNight night;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        if(player.currentHealth<=0)
        {
            Debug.Log("GameOver");
            GameisOver = true;
            gameOver();
        }
        
    }
    void gameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameisOver = true;
        player.canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        night.pause = true;
    }

    public void tryAgain()
    {
        Time.timeScale = 1f;
        Debug.Log("XPtried");
        SceneManager.LoadScene("Skyrim");
    }

}

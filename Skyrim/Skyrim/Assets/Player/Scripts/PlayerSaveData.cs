using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSaveData :MonoBehaviour
{
    public PlayerController player;

    public float[] position;
    public float[] newposition;
    public int health;
    public int newHealth;
    public void Start()
    {
        if(PlayerPrefs.GetInt("Saved")==1 && PlayerPrefs.GetInt("TimetoLoad")==1)
        {
            float px = player.transform.position.x;
            float py = player.transform.position.y;
            float pz = player.transform.position.z;
            int health = player.currentHealth;
            px = PlayerPrefs.GetFloat("p_x");
            py = PlayerPrefs.GetFloat("p_y");
            pz = PlayerPrefs.GetFloat("p_z");
            health = PlayerPrefs.GetInt("health");
            PlayerPrefs.SetInt("TimetoLoad", 0);
            PlayerPrefs.Save();
        }
    }
    public void SavePlayers()
    {

        PlayerPrefs.SetFloat("p_x", player.transform.position.x);
        PlayerPrefs.SetFloat("p_y", player.transform.position.y);
        PlayerPrefs.SetFloat("p_z", player.transform.position.z);
        PlayerPrefs.Save();
        //Health
        PlayerPrefs.SetInt("health", player.currentHealth);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("health"));
        PlayerPrefs.SetInt("Saved", 1);
    }

    public void LoadPlayers()
    {
        PlayerPrefs.SetInt("TimetoLoad", 1);
        PlayerPrefs.Save();
    }



}

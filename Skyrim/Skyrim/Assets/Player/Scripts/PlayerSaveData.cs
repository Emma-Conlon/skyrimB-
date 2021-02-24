using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSaveData 
{

    public float[] position;
    public float[] newposition;
    public int health;
    public int newHealth;
    public  PlayerSaveData(PlayerController player)
    {
        health = player.currentHealth;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

  
    
}

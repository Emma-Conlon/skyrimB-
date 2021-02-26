using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public PlayerController player;

   public bool back;
    // Start is called before the first frame update
    void Start()
    {
        back = false;
    }

    // Update is called once per frame
   public void BackOFF()
    {
        player.lookActive = false;
        player.canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}

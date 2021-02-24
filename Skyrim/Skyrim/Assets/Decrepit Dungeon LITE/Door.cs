using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public GameObject door;
    bool isinRange = false;
    private bool open = false;
    private bool once = true;
    public UnityEvent interactAction;
    public KeyCode interactKey;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)&&once)//opens door
        {
            open = true;
            once = false;
            door.transform.Rotate(new Vector3(0,90,0));
        }
        if (Input.GetKeyDown(KeyCode.L)&&open)//closes door 
        {
            door.transform.Rotate(new Vector3(0, -90, 0));
            open = false;
            once = true;
        }

        if(isinRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isinRange = true;
            Debug.Log("Player IS in range");
        }
    }
}

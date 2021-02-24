using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarryObject : MonoBehaviour
{
    public Transform player;
    public Transform cam;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public float throwForce = 10;
    bool hasPlayer = false;
    bool beingCarried = false;
    public int dmg;
    private bool touched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if(dist <=2.5f)
        {
            hasPlayer = true;
            ActionText.GetComponent<Text>().text = "PickUp";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        else
        {
            hasPlayer = false;
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }
        if(hasPlayer&&Input.GetButtonDown("Action"))
        {
            //GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = cam;

            beingCarried = true;
         

        }

        if (beingCarried)
        {
            if (touched)
            {
               // GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }


            if (Input.GetMouseButtonDown(0))
            {
              //  GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                //GetComponent<Rigidbody>().AddForce(cam.forward * throwForce);
            }

            else if (Input.GetMouseButtonDown(1))
            {
               // GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
        
    }

    private void OnTriggerEnter()
    {
        if(beingCarried)
        {
            touched = true;
        }
    }
    
}

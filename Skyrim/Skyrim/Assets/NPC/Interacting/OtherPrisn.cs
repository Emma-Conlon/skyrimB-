using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherPrisn : MonoBehaviour
{
    public float distance;
    public GameObject TextBox;
    public GameObject Npc_Name;
    public GameObject Npc_Text;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ThePlayer;
    private float Random;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        distance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (distance >= 3)
        {
            ActionText.GetComponent<Text>().text = "Talk";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (distance >= 3)
            {
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                StartCoroutine(NpcInteractActive());
            }
        }
    }

    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator NpcInteractActive()
    {
        TextBox.SetActive(true);
        Npc_Name.GetComponent<Text>().text = "Kiernan";
        Npc_Name.SetActive(true);
       
        Npc_Text.GetComponent<Text>().text = "I deserve this";
        Npc_Text.SetActive(true);
        yield return new WaitForSeconds(5.5f);
        Npc_Name.SetActive(false);
        Npc_Text.SetActive(false);
        TextBox.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

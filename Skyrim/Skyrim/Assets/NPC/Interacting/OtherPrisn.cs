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
    public GameObject quest;
    public GameObject quest_txt;
    public GameObject quest_txt2;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject button2;
    public GameObject button1;
    public GameObject ThePlayer;
    public AntLord3 enemy1;
    public enemyAgent enemy2;
    public EnemyAnimation enemy3;
    public bool helped;
    public bool porgress;
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
        Npc_Name.GetComponent<Text>().text = "QA";
        Npc_Name.SetActive(true);
       
        Npc_Text.GetComponent<Text>().text = "Can you Kill all the enemies please";
        Npc_Text.SetActive(true);
        yield return new WaitForSeconds(5.5f);
        Npc_Name.SetActive(false);
        Npc_Text.SetActive(false);
        TextBox.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if(porgress)
        {
            TextBox.SetActive(true);
            Npc_Name.GetComponent<Text>().text = "QA";
            Npc_Name.SetActive(true);
            Npc_Text.GetComponent<Text>().text = "Did you do it";
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
  if(enemy1.currentHealth==0 && enemy2.currentHealth == 0 && enemy3.currentHealth == 0)
        {
            helped = true;
            Npc_Name.GetComponent<Text>().text = "QA";
            Npc_Name.SetActive(true);
            Npc_Text.GetComponent<Text>().text = "Thanks";
            Npc_Text.SetActive(true);
        }
        if (enemy1.currentHealth >= 0 && enemy2.currentHealth > 0 && enemy3.currentHealth >0)
        {
            helped = false;
            TextBox.SetActive(true);
            Npc_Name.GetComponent<Text>().text = "QA";
            Npc_Name.SetActive(true);
            Npc_Text.GetComponent<Text>().text = "Did you do it";
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

   public void YES()
    {
     
        quest.SetActive(true);
        quest_txt.GetComponent<Text>().text = "Kill all surronding enemies";
        quest_txt.SetActive(true);
    }


    void done()
    {
        
        quest.SetActive(true);
        quest_txt.GetComponent<Text>().text = "killed them all";
        quest_txt.SetActive(true);
        quest.SetActive(true);
        quest_txt2.GetComponent<Text>().text = "Done";
        quest_txt2.SetActive(true);
    }    
}

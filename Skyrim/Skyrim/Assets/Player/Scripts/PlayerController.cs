using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public GameObject Objectives;
    public Quest quests;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Vector3 newPos;
    public DayNight day;
    public GameObject menus;
    public GameObject gameover;
    public float InputX;
    public float InputY;
    public float Sprint;
    public float Crouch;
    public float Jump;
    public GameObject ques;
    public GameObject CUBE;
    public float Extra;
    [HideInInspector]
    public bool pause;
    private bool isRunning = false;
    [HideInInspector]
    public bool resume = false;
    public bool lookActive = true;
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public GameObject Npc_Text;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    private bool menuSystem = true;
  
  
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Quest"))
        {
            Debug.Log("Work");
            CUBE.SetActive(false);
            text();
            ques.SetActive(true);
            CUBE.
        }
    }
    IEnumerator text()
    {
        Npc_Text.GetComponent<Text>().text = "COMPLETED QUEST 1";
        Npc_Text.SetActive(true);
        yield return new WaitForSeconds(5.5f);
        ques.SetActive(false);
    }

    public void SavePlayers()
    {
        SaveSystem.SavePlayer(this);
        PlayerPrefs.GetInt("health",currentHealth);

        Debug.Log(PlayerPrefs.GetInt("health"));
    }

    public void NewGame()
    {
       
    }

    public void lostHealth()
    {
        gameover.SetActive(true);
    }

    public void LoadPlayers()
    {
        PlayerSaveData data = SaveSystem.LoadPlayer();
        currentHealth = data.health;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        menus.SetActive(false);
        menuSystem = true;
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pause = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        // Get the animator
        animator = this.gameObject.GetComponent<Animator>();
    }
   
    void Update()
    {
        // Get inputs for animations
        InputY = Input.GetAxis("Vertical");
        InputX = Input.GetAxis("Horizontal");
        Sprint = Input.GetAxis("Sprint");
        Crouch = Input.GetAxis("Crouch");
        Jump = Input.GetAxis("Jump");
        Extra = Input.GetAxis("Extra");
        animator.SetFloat("InputY", InputY);
        animator.SetFloat("InputX", InputX);
        animator.SetFloat("Sprint", Sprint);
        animator.SetFloat("Crouch", Crouch);
        animator.SetFloat("Jump", Jump);
        animator.SetFloat("Extra", Extra);

        // Recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        if (InputX == 0)
        {
            isRunning = Input.GetKey(KeyCode.LeftShift);
        }
        else
        {
            isRunning = false;
        }

        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Crouch < 0.1f)
        {
            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
       
            if (canMove)
            {
     
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }

        //temporary health system
          if(Input.GetKeyDown(KeyCode.H))
          {
            TakeDamage(5);
            if(currentHealth<=0)
            {
                lostHealth();
            }
          }


          

        if(Input.GetKeyDown(KeyCode.P))
        PauseScreen();

        if (Input.GetKeyDown(KeyCode.Q))
            Quests();

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    /// <summary>
    /// controls the pause menu :)
    /// </summary>
   private void PauseScreen()
    {
        if (Input.GetKeyDown(KeyCode.P))//pause 
        {
        
            if (lookActive == true)
            {
                // Lock cursor
                menuSystem = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                lookActive = false;
                canMove = true;
                quests.back = false;
                day.pause = false;
                pause = false;
            }
            else
            {
                pause = true;
                // Lock cursor
                Cursor.lockState = CursorLockMode.None;
                //Cursor.visible = true;
                lookActive = false;
                quests.back = true;
                canMove = false;
                day.pause = true;

            }
            
        }
    }
    private void Quests()
    {
        if (Input.GetKeyDown(KeyCode.Q))//pause 
        {

            if (lookActive == true)
            {
                Objectives.SetActive(false);
                // Lock cursor
                menuSystem = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                lookActive = false;
                canMove = true;
                day.pause = false;
            
            }
            else
            {
                Objectives.SetActive(true);
                // Lock cursor
                Cursor.lockState = CursorLockMode.None;
                //Cursor.visible = true;
                lookActive = false;
                canMove = false;
                day.pause = true;

            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    public PlayerController player;
    public Animator animator;
    public GameObject enemy;
    public float moveSpeed = 3f;
    public float rotSpeed = 200f;
    public int maxHealth = 100;
    public int currentHealth;
    Vector3 pos;
    public HealthBar healthBar;
    //my private varaibles 
    private bool isWandering = false;
    private bool isWalking = false;
    private bool PlayerNotFound = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private float viewDis = 20.0f;
    private float fightDis = 5.0f;
    private float close = 2.0f;
    private Vector3 temp;
    NavMeshAgent theAgent;
    //yes 
    // Start is called before the first frame update
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }
    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    // Update is called once per frame
    /// <summary>
    /// the enemy wont move unless he is near player
    /// </summary>
    void Update()
    {
        if (isWandering == false && PlayerNotFound == false)
        {
            StartCoroutine(Wander());
        }

        if (isRotatingRight == true && PlayerNotFound == false)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
            //   animator.SetFloat("enemyOneTurnX", 1.0f);
            animator.SetFloat("enemyOneWalk", 1.0f);
        }
        if (isRotatingLeft == true && PlayerNotFound == false)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);


        }

        if (isWalking == true && PlayerNotFound == false)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            animator.SetFloat("enemyOneWalk", 1.0f);
        }

        float dist = Vector3.Distance(player.transform.position, theAgent.transform.position);//distance formula 
        Vector3 gap = Vector3.Normalize(player.transform.position - theAgent.transform.position);

        gap *= close;

        if (dist < viewDis)// he will walk if he is within 30m 
        {
            PlayerNotFound = true;
            Vector3 pos = player.transform.position - gap;
            temp = player.transform.position - gap;
            theAgent.SetDestination(pos);//walks to player 
            animator.SetFloat("enemyOneWalk", 1.0f);
            //if (dist >= fightDis)
            //{

            //}
            //else
            //{
            //    animator.SetFloat("enemyOneWalk", 1.0f);
            //}
        }

        //walks to player )




        if (Input.GetKeyDown(KeyCode.Z))
        {
            takeDamage(10);
        }
        if (currentHealth <= 0)
        {
            enemy.SetActive(false);
        }
        if (Vector3.Distance(temp, theAgent.transform.position) <= 0.1f)//once it hits zero or less than 0 then he will stop moving
        {
            PlayerNotFound = true;
            animator.SetFloat("enemyOneWalk", 0.0f);
        }
        else
        {
            PlayerNotFound = false;

        }

        //  Debug.Log(Vector3.Distance(temp, theAgent.transform.position));
    }


    /// <summary>
    /// he is meant to walk in any direction 
    /// </summary>
    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(1, 2);//left or right 
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 15);

        isWandering = true;
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        animator.SetFloat("enemyOneWalk", 0.0f);
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        animator.SetFloat("enemyOneWalk", 0.0f);
        yield return new WaitForSeconds(rotateWait);

        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            // animator.SetFloat("enemyTurnX", 0.1f);
            animator.SetFloat("enemyOneWalk", 1.0f);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)//rotates left 
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;

        }
        isWandering = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            animator.SetFloat("enemyPunch", 1.0f);
        }
    }
}

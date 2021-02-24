using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OtherNpc : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotSpeed = 200f;
    public Animator animator;
    //my private varaibles 
    private bool isWandering = false;
    private bool isWalking = true;

    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;

    // Start is called before the first frame update
    void Start()
    {

        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }

        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);

        }
        if (isRotatingLeft == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);

        }

        if (isWalking == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            animator.SetFloat("arrowWalk", 1.0f);
            Debug.Log("SHOULD WALK");
        }


        // </summary>
        IEnumerator Wander()
        {
            int rotTime = Random.Range(1, 3);
            int rotateWait = Random.Range(1, 4);
            int rotateLorR = Random.Range(1, 2);//left or right 
            int walkWait = Random.Range(1, 4);
            int walkTime = Random.Range(1, 5);

            isWandering = true;
            yield return new WaitForSeconds(walkWait);
            isWalking = true;
            animator.SetFloat("knightWalk", 1.0f);
            yield return new WaitForSeconds(walkTime);
            animator.SetFloat("knightWalk", 0.0f);
            isWalking = false;

            yield return new WaitForSeconds(rotateWait);

            if (rotateLorR == 1)
            {
                isRotatingRight = true;
                yield return new WaitForSeconds(rotTime);
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
    }
}

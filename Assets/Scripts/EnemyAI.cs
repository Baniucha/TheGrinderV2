using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT IS RESPONSIBLE FOR ENEMY AI 

public class EnemyAI : MonoBehaviour
{
    //VARIABLES
    public float walkSpeed = 1.0f;
    public float wallLeft = 0.0f;
    public float wallRight = 5.0f;
    public float walkingDirection = 1.0f;
    Vector2 walkAmount;
    float originalX;

    public Transform changer, changerBot, player;
    public bool test;
    public int tester;
    public bool goHorizontal;
    void Start()
    {
        //SET VARIABLES
        goHorizontal = true;
        this.originalX = this.transform.position.x;
    }
    void Update()
    {
        //DEPENDING ON TESTER VALUE
        //PERFORM DIFFERENT MOVEMENT THAT STIMULATES PATROLLING

        if (tester == 6)
        {
            goHorizontal = false;
            MoveUp();
        }
        else if (tester == 7 || goHorizontal)
        {

            MoveRightLeft();
        }
        else if (tester == 9)
        {
            goHorizontal = false;
            MoveDown();
        }
        else if (tester == 11)
        {
            goHorizontal = true;
            MoveRightLeft();
        }
        if (tester == 7)

        {
            goHorizontal = true;
        }
        else if (tester == 9)
        {
            goHorizontal = false;
        }
        else if (tester >= 10)
        {
            goHorizontal = true;
        }
        if (tester >= 13)
        {
            tester = 0;
            goHorizontal = true;


        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //ADD 1 TO TESTER VALUE DEPENDING ON TRIGGERS

        if (other.CompareTag("test"))
        {
            tester++;
        }
        if (other.CompareTag("tester"))
        {
            tester++;
        }
        if (other.CompareTag("testerBot"))
        {
            tester++;
        }


    }

    //BELOW FUNCTIONS RESPONSIBLE FOR MOVEMENT HORIZONTAL AND VERTICAL

    public void MoveUp()
    {
        walkAmount.x = 0;
        walkAmount.y = walkingDirection * (-walkSpeed) * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, changer.position, walkSpeed * Time.deltaTime);

    }
    public void MoveDown()
    {

        walkAmount.y = walkingDirection * (-walkSpeed) * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, changerBot.position, walkSpeed * Time.deltaTime);
    }
    public void MoveRightLeft()
    {


        walkAmount.y = 0;
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;



        if (walkingDirection > 0.0f && transform.position.x >= originalX + wallRight)
        {
            walkingDirection = -1.0f;

        }
        else if (walkingDirection < 0.0f && transform.position.x <= originalX - wallLeft)
        {
            walkingDirection = 1.0f;

        }

        transform.Translate(walkAmount);


    }
}
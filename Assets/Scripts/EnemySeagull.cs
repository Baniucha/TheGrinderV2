﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//SCRIPT RESPONSIBLE FOR SEAGULL ENEMY
public class EnemySeagull : MonoBehaviour
{
    //VARIABLES
    public float speed;
    public bool moveRight;
  public  int r;
    public Transform player,startPos;
    public PlayerAttack playerGO;
     Vector3 smoothVelocity = Vector3.zero;
    public float smoothTime = 10.0f;
   public bool goBack;
    public Player playerPosRef;
    int dmg = 5;
    // Start is called before the first frame update
    void Start()
    {
        //SET VARIABLES
        speed = 7; 
        playerGO = GameObject.FindObjectOfType<PlayerAttack>();

    }

    // Update is called once per frame
    void Update()
    {
        //WANDER BETWEEN TWO POINTS
        //IF PLAYER IS ON SAND GROUND 
        //DEPENDING ON RNG MOVE TO PLAYER AND ATTACK PLAYER
        //ELSE WANDER BETWEEN TWO POINTS
        if (playerPosRef.onSandPos)
        {
            if (!goBack)
            {
                if (r != 3)
                {
                    StopAllCoroutines();
                    speed = 7;
                    if (moveRight)
                    {
                        transform.Translate(speed * Time.deltaTime, 0, 0);
                    }
                    else
                    {
                        transform.Translate(-speed * Time.deltaTime, 0, 0);
                    }
                }
                else
                {
                    StartCoroutine("AttackPlayer");
                }
            }
            else
            {
                StartCoroutine("Back");
            }
        }
        else
        {
            if (moveRight)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                if(transform.rotation!=Quaternion.Euler(0,0,0))
                    {
                    transform.rotation = Quaternion.Euler(0, 0, 0);

                }
            }
            else
            {
                transform.rotation = Quaternion.Euler(0,-180, 0);
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                if(transform.rotation != Quaternion.Euler(0, -180, 0))
                {
                    transform.rotation = Quaternion.Euler(0, -180, 0);
                }
            }
        }
    }
    //SET RNG ON TRIGGER
    //IF TRIGGERS WITH PLAYER
    //ATTACK PLAYER AND GO BACK TO WANDERING
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Turn"))
        {
            if(moveRight)
            {
                r = Random.Range(0, 4);
                moveRight = false;
            }
            else
            {
                r = Random.Range(0, 4);
                moveRight = true;
            }
        }
        if(collision.CompareTag("Player"))
        {
            if (!playerGO.imShielding)
            {
                playerGO.GetComponent<invulnerability>().PlayerTakesDmg(dmg);
            }
                StopCoroutine("AttackPlayer");
            goBack = true;
        }
    }
    //COROUTINE THAT ATTACKS PLAYER AND WAIT 2 SECONDS TO ALLOW PLAYER TO REACT
    
    IEnumerator AttackPlayer()
    {
        speed = 0;
        yield return new WaitForSeconds(2f);
        speed = 20;
        transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed*Time.deltaTime);
    }
    //COROUTINE THAT ALLOWS SEAGULL GO BACK TO WANDERING
    IEnumerator Back()
    {
        yield return new WaitForSeconds(.1f);
        transform.position = Vector3.MoveTowards(transform.position, startPos.position, speed * Time.deltaTime);
        if(transform.position == startPos.position)
        {
            r = Random.Range(0, 1);
            goBack = false;
        }
    }
}

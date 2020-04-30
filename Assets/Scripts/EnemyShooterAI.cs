using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//SCRIPT RESPONSIBLE FOR ENEMY SHOOTER AI
public class EnemyShooterAI : MonoBehaviour
{

    //VARIABLES
    public float speed;
    public float stopDist;
    public float retreatDist;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        //FIND PLAYER
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //DEPENDING ON DISTANCE MOVE TO PLAYER OR RUN AWAY FROM PLAYER
        if (Vector2.Distance(transform.position, player.position) > stopDist)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position,player.position)<stopDist&&Vector2.Distance(transform.position,player.position)>retreatDist)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position,player.position)<retreatDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
    }
}

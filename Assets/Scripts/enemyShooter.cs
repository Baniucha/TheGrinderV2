using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT RESPONSIBLE FOR SHIP SHOOTING 
public class enemyShooter : MonoBehaviour
{
    //VARIABLES
    public GameObject bullet;
    public Audio audio;
    float fireRate;
    float nextFire;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        //SET VARIABLES
        fireRate = Random.Range(0,6);
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //IF PLAYER IS ON SAND GROUND AND IT IS TIME TO SHOOT
        //INSTANTIATE CANNON BULLET AND SET TIME BACK AGAIN TO ORIGINAL STATE
        if (player.onSandPos)
        {
            if (Time.time > nextFire)
            {
                audio.cannon.Play();
                Instantiate(bullet, transform.position, Quaternion.identity);
                nextFire = Time.time + fireRate;
            }
        }
    }
}

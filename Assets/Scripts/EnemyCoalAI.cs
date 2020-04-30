using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//SCRIPT RESPONSBILE FOR ENEMY COAL AI
public class EnemyCoalAI : MonoBehaviour
{
    //VARIABLES
     Vector3 pos1 = new Vector3(48, -8.5f, 0);
     Vector3 pos2 = new Vector3(52, -8.5f, 0);
     Vector3 pos3 = new Vector3(60.5f, -8.5f, 0);
     Vector3 pos4 = new Vector3(64.5f, -8.5f, 0);

    public float speed = 1.0f;
    public CoalGround player;
    public GameObject bullet;
    public Audio audio;
    float fireRate;
    float nextFire;
   
    // Start is called before the first frame update
    void Start()
    {
        //SET VARIABLES
        fireRate = Random.Range(1,5);
        nextFire = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        //DEPENDING ON OBJECT'S TAG
        //ENEMY MOVES TO DIFFERENT POSITIONS AND THEN SHOOTS AT PLAYER
        //NEXT SHOOT IS DEPENDABLE ON RNG
        //IF PLAYER IS NOT ON COAL GROUND
        //ENEMY WANDERS FROM LEFT TO RIGHT
        if (this.gameObject.tag == "EnemyCoal")
        {
            if (player.c1)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos1, speed * Time.deltaTime);
                if (Time.time > nextFire)
                {
                    audio.gunShot.Play();
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    nextFire = Time.time + fireRate;
                }
            }
            else if (player.c2)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos2, speed * Time.deltaTime);
                if (Time.time > nextFire)
                {
                    audio.gunShot.Play();
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    nextFire = Time.time + fireRate;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
            }
        }




        else if(this.gameObject.tag=="EnemyCoal1")
        {
            if (player.c2)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos3, speed * Time.deltaTime);
                if (Time.time > nextFire)
                {
                    audio.gunShot.Play();
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    nextFire = Time.time + fireRate;
                }
            }
            else if (player.c3)
            {
                transform.position = Vector3.MoveTowards(transform.position,pos4 , speed * Time.deltaTime);
                if (Time.time > nextFire)
                {
                    audio.gunShot.Play();
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    nextFire = Time.time + fireRate;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(pos3,pos4 , (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
            }
        }

    }


}

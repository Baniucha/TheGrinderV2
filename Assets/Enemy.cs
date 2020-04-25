using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float speed;
    float stunnedTime;
    public float startStunnedTime;
    public ParticleSystem blood;
    public bool bleed;
    int r,rHP;
    public GameObject coin;
    public GameObject bigCoin;
    public Rigidbody2D smallHP;
    Transform thisTransform;
    CoalEnemyManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("EnemyManager").GetComponent<CoalEnemyManager>();
        thisTransform = GetComponent<Transform>();
        if(this.gameObject.tag=="EnemyCoal" || this.gameObject.tag == "EnemyCoal1")
        {
            health = 3;
        }
    }
    private void OnEnable()
    {
        if(this.tag=="StoneEnemy")
        {
            
            transform.GetComponent<Rigidbody2D>().WakeUp();
        
        }
    }
    private void OnDisable()
    {
        if (this.tag == "StoneEnemy")
        {

            transform.GetComponent<Rigidbody2D>().Sleep();

        }
    }
    // Update is called once per frame
    void Update()
    {

        if(stunnedTime<=0)
        {
            speed = 5;
        }
        else
        {
            speed = 0;
            stunnedTime -= Time.deltaTime;
        }
        //Movement / FSM
        if (health <= 0&& this.tag!="EnemyCoal"&&this.tag!="EnemyCoal1")
        {
                RandomCoin();
                Destroy(gameObject);
        }
        if((this.tag=="EnemyCoal" && health<=0) || (this.tag == "EnemyCoal1"&&health<=0))
        {
            this.gameObject.SetActive(false);
        }

  
        
    }

    void RandomCoin()
    {
        print(r);
        r = Random.Range(1, 6);
        rHP = Random.Range(0, 9);
        if (r == 1)
        {
            Instantiate(coin, thisTransform.position, Quaternion.identity);
        }
        else if (r == 2)
        {
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(coin, thisTransform.position, Quaternion.identity);
        }
        else if (r == 3)
        {
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(coin, thisTransform.position, Quaternion.identity);

        }
        else if (r == 4)
        {
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(coin, thisTransform.position, Quaternion.identity);

        }
        else if (r == 5)
        {
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(coin, thisTransform.position, Quaternion.identity);

        }
        else if (r == 6)
        {
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(coin, thisTransform.position, Quaternion.identity);
            Instantiate(bigCoin, thisTransform.position, Quaternion.identity);
        }
        if(rHP==1)
        {
            Rigidbody2D rb;
           rb= Instantiate(smallHP, thisTransform.position, transform.rotation);
            rb.velocity = transform.TransformDirection(Vector3.up * 10);
        }
    }
    public void TakeDamage(int dmg)
    {
        blood.time = 0;
        blood.Play();
        stunnedTime = startStunnedTime;
        health -= dmg;

    }
   

}

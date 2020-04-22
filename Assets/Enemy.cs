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

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();

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
        transform.GetComponent<Rigidbody2D>().Sleep();  
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
        if (health <= 0)
        {
            if (this.tag == "StoneChaser")
            {
                RandomCoin();
                gameObject.SetActive(false);
                health = 5;
            }
            else
            {
                RandomCoin();
                Destroy(gameObject);
            }
        }
        if(this.tag=="TreeChaser"&& health<=0)
        {
            Destroy(this.gameObject);
        }
        if (health<=0 && this.tag =="StoneEnemy")
        {
            gameObject.SetActive(false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    float stunnedTime;
    public float startStunnedTime;
    public ParticleSystem blood;
   public bool bleed;
    // Start is called before the first frame update
    void Start()
    {

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
        if(health<=0)
        {
            Destroy(gameObject);
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

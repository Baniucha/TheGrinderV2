using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooter : MonoBehaviour
{
    public GameObject bullet;
    public Audio audio;
    float fireRate;
    float nextFire;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 5f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT RESPONSIBLE FOR SPAWNING ENEMIES ON STONE GROUND
public class SpawnerStone : MonoBehaviour
{
    //VARIABLES
    public GameObject enemyPrefab;
    GameObject[] go;
    public Transform spawn1, spawn2, spawn3;
    int r;
    public Player playerRef;
    public bool canResp;
    public float cooldown = 5;


    // Update is called once per frame
    void Update()
    {
        //IF IT IS POSSIBLE TO RESPAWN
        //RESPAWN ENEMY ON DIFFERENT POSITION DEPENDING ON RNG
        if (canResp)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                r = Random.Range(0, 3);
                if (r == 0)
                {
                    Instantiate(enemyPrefab, spawn1.transform.position, Quaternion.identity);
                    cooldown = 5;
                }
                if (r == 1)
                {
                    Instantiate(enemyPrefab, spawn2.transform.position, Quaternion.identity);
                    cooldown = 5;
                }
                if (r == 2)
                {
                    Instantiate(enemyPrefab, spawn3.transform.position, Quaternion.identity);
                    cooldown = 5;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //IF PLAYER TRIGGERS WITH THIS OBJECT ALLOW FOR RESPAWNING ENEMIES
        if (collision.CompareTag("Player"))
        {
            canResp = true;
        }
    }

    //IF PLAYER LEAVES TRIGGER
    //DESTROY ALL ENEMIES ON STONE GROUND
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canResp = false;
            go = GameObject.FindGameObjectsWithTag("StoneEnemy");
            for (int i = 0; i < go.Length; i++)
            {
                Destroy(go[i]);
            }
        }
    }
}


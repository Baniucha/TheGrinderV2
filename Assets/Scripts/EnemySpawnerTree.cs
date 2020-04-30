using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT RESPONSIBLE FOR SPAWNING ENEMIES ON TREE GROUND
public class EnemySpawnerTree : MonoBehaviour
{

    //VARIABLES
    public GameObject enemyPrefab;
    GameObject[] go;
    public Transform spawn1, spawn2;
    int r;
    public Player playerRef;
    public  bool canResp;
    public float cooldown = 3;

    private void Update()
    {
    
        //IF POSSIBLE INSTANTIATE ENEMY ON POSITION WHICH DEPENDS ON RNG
        if (canResp)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
            r = Random.Range(0, 2);
                if(r==0)
                {
                    Instantiate(enemyPrefab, spawn1.transform.position, Quaternion.identity);
                    cooldown = 3;
                }
                if (r == 1)
                {
                    Instantiate(enemyPrefab, spawn2.transform.position, Quaternion.identity);
                    cooldown = 3;
                }
         
            }
        }
    }

 

    //IF PLAYER IS ON TREE GROUND ALLOW RESPAWNING ENMIES
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            canResp = true;
        }
    }
    //IF PLAYER EXITS TRIGGER 
    //DESTORY ALL ENEMIES
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            canResp = false;
            go = GameObject.FindGameObjectsWithTag("TreeChaser");
            for (int i = 0; i < go.Length; i++)
            {
                Destroy(go[i]);
            }
        }
    }
}

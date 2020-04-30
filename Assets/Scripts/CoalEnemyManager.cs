using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT RESPONSIBLE FOR ENEMIES IN COAL GROUND
public class CoalEnemyManager : MonoBehaviour
{

    //VARIABLES
    public GameObject enemy1, enemy2;
    


    //FIND OBJECTS ON ENABLE AND ON START
    // Start is called before the first frame update
    private void OnEnable()
    {
        enemy1 = GameObject.Find("EnemyCoal1");
        enemy2 = GameObject.Find("EnemyCoal2");
    }
    void Start()
    {
        enemy1 =GameObject.Find("EnemyCoal1");
        enemy2 = GameObject.Find("EnemyCoal2");


    }

    // Update is called once per frame
    void Update()
    {
        //if enemy is disabled
        //set movement speed to 0 
        //start coroutine
        if (!enemy1.activeInHierarchy)
        {
            enemy1.GetComponent<EnemyCoalAI>().speed = 0;
            StartCoroutine("Spawn");
        }
        
        if(!enemy2.activeInHierarchy)
        {
            enemy2.GetComponent<EnemyCoalAI>().speed = 0;
            StartCoroutine("Spawn2");
        }
    }

    //COROUTINES RESPONSIBLE FOR ENABLING BACK ENEMIES IN ORDER TO IMPROVE PERFORMANCE
    //AFTER 5 SECONDS ENEMY IS ENABLED AGAIN AND SPEED AND HEALTH IS SET BACK AGAIN TO ORIGINAL VALUE
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5f);
        enemy1.gameObject.SetActive(true);
        enemy1.GetComponent<EnemyCoalAI>().speed = 1;
        enemy1.GetComponent<Enemy>().health = 3;
    }
    IEnumerator Spawn2()
    {
        yield return new WaitForSeconds(5f);
        enemy2.gameObject.SetActive(true);
        enemy2.GetComponent<EnemyCoalAI>().speed = 1;
        enemy2.GetComponent<Enemy>().health = 3;
    }
}

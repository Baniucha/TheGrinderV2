using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalEnemyManager : MonoBehaviour
{
    public GameObject enemy1, enemy2;
    
    float nextSpawn;
    float spawnRate;
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
        spawnRate= 5;
        nextSpawn = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
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

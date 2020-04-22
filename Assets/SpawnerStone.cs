using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerStone : MonoBehaviour
{
    public GameObject enemyPrefab;
    GameObject[] go;
    public Transform spawn1, spawn2, spawn3;
    int r;
    public Player playerRef;
    public bool canResp;
    public float cooldown = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        if (collision.CompareTag("Player"))
        {
            canResp = true;
        }
    }

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


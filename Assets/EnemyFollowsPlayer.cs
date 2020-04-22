using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowsPlayer : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float step;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine("Wait");    
    }
 
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
    IEnumerator Wait()
    {
        speed = 0;
        yield return new WaitForSeconds(2f);
        speed = 5;
        step = speed * Time.deltaTime;
    }
}

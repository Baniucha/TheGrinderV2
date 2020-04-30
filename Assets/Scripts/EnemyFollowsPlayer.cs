using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//SCRIPT RESONSIBLE FOR FOLLOWING PLAYER
public class EnemyFollowsPlayer : MonoBehaviour
{

    //VARIABLES
    public GameObject player;
    public float speed;
    public float step;
    // Start is called before the first frame update
    void Start()
    {
        //SET VARIABLES
        player = GameObject.Find("Player");
        StartCoroutine("Wait");    
    }
 
    // Update is called once per frame
    void Update()
    {
        //MOVE TO PLAYER
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
    IEnumerator Wait()
    {//WHEN OBJECT IS CREATED GIVE IT HALF SECOND BEFORE IT MOVES
        speed = 0;
        yield return new WaitForSeconds(.5f);
        speed = 5;
        step = speed * Time.deltaTime;
    }
}

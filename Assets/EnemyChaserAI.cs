using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaserAI : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float wallLeft = 0.0f;
    public float wallRight = 5.0f;
    public float walkingDirection = 1.0f;
    Vector2 walkAmount;
    float originalX;
    float zero = 0;
    float finalWalkSpeed = 3;
    float finalMoveSpeed = 4;
    public Transform player;
    public float moveSpeed = 4;
    public float lookRadius = 5f;
    
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        this.originalX = this.transform.position.x;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target = PlayerManager.instance.player.transform;
        StartCoroutine("WaitAfterChase");

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance >= lookRadius)
        {

            walkAmount.y = 0;
            walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
            if (walkingDirection > 0.0f && transform.position.x >= originalX + wallRight)
            {

                walkingDirection = -1.0f;

            }
            else if (walkingDirection < 0.0f && transform.position.x <= originalX - wallLeft)
            {

                walkingDirection = 1.0f;

            }

          //  StartCoroutine("WaitAfterChase");
            transform.Translate(walkAmount);
        }
        if (distance <= lookRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }

        
    }

    IEnumerator WaitAfterChase()
    {
        walkSpeed = zero;
        moveSpeed = zero;
        yield return new WaitForSeconds(.5f);
        walkSpeed = finalWalkSpeed;
        moveSpeed = finalMoveSpeed;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        
    }

}

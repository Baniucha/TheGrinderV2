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
    float finalWalkSpeed=3;
    float finalMoveSpeed=4;
    bool gonnaChaseThePlayer;
    public Transform player;
    float moveSpeed = 4;


    // Start is called before the first frame update
    void Start()
    {
        gonnaChaseThePlayer = false;
        this.originalX = this.transform.position.x;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gonnaChaseThePlayer)
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

            transform.Translate(walkAmount);
        }
        else if(gonnaChaseThePlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gonnaChaseThePlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            {
            gonnaChaseThePlayer = false;
            StartCoroutine("WaitAfterChase");
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
}

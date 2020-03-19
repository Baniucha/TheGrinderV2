using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public bool onPos1, onPos2, onPos3;
    public float jumpForce;
    public float checkRadius;
    public float jumpTime=0.3f;
    public int extraJumpsValue;
    public Transform feetPos;
    public LayerMask whatIsGround;
    public PowerUp powerUpRef;
    bool isGrounded;
    bool isJumping;
    float moveInput;
    float jumpTimeCounter;
    int extraJumps;
    public float maxHealth = 100f;
    public float actualHealth;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        actualHealth = maxHealth;
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        onPos1 = onPos2 = false;
    }

    private void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        //Rotate
        if(moveInput>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(moveInput<0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            if (jumpTimeCounter > 0 && isJumping)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        else
        {
            isJumping = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            {
            isJumping = false;
        }
        if (powerUpRef.doubleJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
            if (isGrounded)
            {
                extraJumps = extraJumpsValue;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
     
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag != "Detector")
        {
            if (other.CompareTag("Ground1"))
            {
                onPos1 = true;
            }
            if (other.CompareTag("Ground2"))
            {
                onPos2 = true;
            }
            if (other.CompareTag("Ground3"))
            {
                onPos3 = true;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground1"))
        {
            onPos1 = false;
        }
        if (other.CompareTag("Ground2"))
        {
            onPos2 = false;
        }
        if (other.CompareTag("Ground3"))
        {
            onPos3 = false;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public bool onPos1, onPos2, onPos3, onPos22, onSandPos, onClayPos, onCoalPos;
    public float jumpForce;
    public float checkRadius;
    public float jumpTime = 0.3f;
    public int extraJumpsValue;
    public Transform feetPos;
    public LayerMask whatIsGround;
    public LayerMask ladderMask;
    public LayerMask ladderDownMask;
    public PowerUp powerUpRef;
    bool isGrounded;
    bool isJumping;
    float inputHorizontal;
    float inputVertical;
    float jumpTimeCounter;
    public float distance;
    int extraJumps;
    public float maxHealth;
    public float actualHealth;
    public float air;
    public float maxAir;
    Rigidbody2D rb;
    public Item itemRef;
    public bool ableToGoUp;
    public bool ableToGoDown;
    public Audio audio;
    public bool swim;
    // Start is called before the first frame update
    void Start()
    {
        maxAir = 100;
        air = maxAir;
        maxHealth = 100;
        ableToGoUp = false;
        ableToGoDown = false;
        actualHealth = maxHealth;
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        onPos1 = onPos2 = false;
    }

    private void Update()
    {
        if (actualHealth > maxHealth)
        {
            actualHealth = maxHealth;
        }
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        ableToGoDown = Physics2D.OverlapCircle(feetPos.position, checkRadius, ladderDownMask);
        //Rotate
        if (inputHorizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (inputHorizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space))
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
       if(ableToGoDown&&Input.GetKeyDown(KeyCode.S))
        {
            this.GetComponent<Collider2D>().isTrigger = true;
        }
       else if (!ableToGoDown&& !ableToGoUp)
        {
            this.GetComponent<Collider2D>().isTrigger = false;
        }
        if (air > maxAir)
        {
            air = maxAir;
        }
        if (air <= 0)
        {
            air = 0;
            actualHealth -= Time.deltaTime * 4;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, ladderMask);
        if (hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                ableToGoUp = true;
            }
        }
        else
        {
            ableToGoUp = false;
        }
        if (ableToGoUp)
        {
            this.GetComponent<Collider2D>().isTrigger = true;
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
            rb.gravityScale = 0;
        }
        else if (swim)
        {
            air -= Time.deltaTime * 5f;
          jumpForce = 3;
            rb.gravityScale = 1f;
        }
        else
        {
            air += Time.deltaTime * 5f;
            jumpForce = 15;
            rb.gravityScale = 5;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Swim"))
        {
            swim = true;
        }
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
        if (other.CompareTag("Ground22"))
        {
            onPos22 = true;
        }
        if(other.CompareTag("GroundSand"))
        {
            onSandPos = true;
        }
        if (other.CompareTag("GroundClay"))
        {
            onClayPos = true;
        }
        if(other.CompareTag("GroundCoal"))
        {
            onCoalPos = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Swim"))
        {
            swim = false;
        }
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
        if (other.CompareTag("Ground22"))
        {
            onPos22 = false;
        }
        if(other.CompareTag("GroundSand"))
        {
            onSandPos = false;
        }
        if(other.CompareTag("GroundClay"))
        {
            onClayPos = false;
        }
        if(other.CompareTag("Fish"))
        {
            actualHealth -= 2.5f;
        }
        if (other.CompareTag("GroundCoal"))
        {
            onCoalPos = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wood")
        {
            audio.pickUp.Play();
            Destroy(collision.gameObject);
            itemRef.woodAmount++;
        }
        if (collision.gameObject.tag == "Coin")
        {
            audio.pickUp.Play();
            Destroy(collision.gameObject);
            itemRef.coin += 3;
        }
        if (collision.gameObject.tag == "BigCoin")
        {
            audio.pickUp.Play();
            Destroy(collision.gameObject);
            itemRef.coin += 10;
        }
        if (collision.gameObject.tag == "Stone")
        {
            audio.pickUp.Play();
            Destroy(collision.gameObject);
            itemRef.stoneAmount++;
        }
        if (collision.gameObject.tag == "SmallHP")
        {
            audio.pickUp.Play();
            Destroy(collision.gameObject);
            actualHealth += 15;
        }
       if(collision.gameObject.tag=="Sand")
        {
            audio.pickUp.Play();
            Destroy(collision.gameObject);
            itemRef.stoneAmount++;
        }
       if(collision.gameObject.tag=="SandStone")
        {
            audio.pickUp.Play();
            Destroy(collision.gameObject);
            itemRef.sandstoneAmount++;
        }
        if (collision.gameObject.tag == "Clay")
        {
            audio.pickUp.Play();
            Destroy(collision.gameObject);
            itemRef.clayAmount++;
        }
        if (collision.gameObject.tag == "Brick")
        {
            audio.pickUp.Play();
            Destroy(collision.gameObject);
            itemRef.brickAmount++;
        }
    }

  
}
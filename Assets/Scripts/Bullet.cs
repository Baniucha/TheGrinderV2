using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT RESPONSIBLE FOR CANNON BULLET
public class Bullet : MonoBehaviour
{
    //VARIABLES
    public float moveSpeed = 7f;
    int dmg = 20;
    int smallDmg = 10;
    Player target;
    public PlayerAttack player;
    // Start is called before the first frame update
    void Start()
    {
        //FIND OBJECTS ON START
        target = GameObject.FindObjectOfType<Player>();
        player = GameObject.FindObjectOfType<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        //MOVE TOWARDS PLAYER
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //IF THIS OBJECT COLLIDES WITH PLAYER 
        //AND IF PLAYER IS SHIELDING HURT PLAYER FOR SMALL VALUE
        //ELSE HURT PLAYER FOR BIG DMG
        //DESTROY OBJECT
        if(collision.gameObject.tag=="Player")
        {
            if (!player.imShielding)
            {
                if (this.gameObject.name == "SmallBullet")
                {
                    player.GetComponent<invulnerability>().PlayerTakesDmg(smallDmg);
                }
                else
                {
                    player.GetComponent<invulnerability>().PlayerTakesDmg(dmg);
                }
            }
            Destroy(gameObject);
            
        }
    }
}

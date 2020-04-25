using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 7f;
    int dmg = 20;
    int smallDmg = 10;
    Player target;
    public PlayerAttack player;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<Player>();
        player = GameObject.FindObjectOfType<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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

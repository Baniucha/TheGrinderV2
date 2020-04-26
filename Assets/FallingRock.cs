using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    public float RotationSpeed;
    Player player;
    PlayerAttack shield;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        shield = player.GetComponent<PlayerAttack>();
        RotationSpeed = 400f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * (RotationSpeed * Time.deltaTime));

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if(shield.imShielding)
            {
                player.actualHealth -= 7.5f;
            }
            else { 
            player.actualHealth -= 20;
            
            }
        }
        
        Destroy(gameObject);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT RESPONSIBLE FOR FALLING ROCKS
public class FallingRock : MonoBehaviour
{

    //VARAIBLES
    public float RotationSpeed;
    Player player;
    PlayerAttack shield;
    // Start is called before the first frame update
    void Start()
    {
        //SET VARIABLES
        player = GameObject.Find("Player").GetComponent<Player>();
        shield = player.GetComponent<PlayerAttack>();
        RotationSpeed = 400f;
    }

    // Update is called once per frame
    void Update()
    {
        //SET ROTATION WHICH SIMULATES ROTATING ROCK
        transform.Rotate(Vector3.back * (RotationSpeed * Time.deltaTime));

    }

    //IF PLAYER IS SHIELDING SUBTRACT 7.5 HP
    //IF PLAYER IS NOT SHIELDING SUBTRACT 20HP
    // DESTROY OBJECT ON COLLISION WITH ANY OBJECT
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

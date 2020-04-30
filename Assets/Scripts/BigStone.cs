using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SCRIPT RESPONSIBLE FOR STONE
public class BigStone : MonoBehaviour
{//variables
    public int hpStone = 3;
    public PlayerAttack playerDmg;
    public Rigidbody2D stone;
    public Rigidbody2D diamond;
    public Rigidbody2D silver;
    Transform thisTransform;
    Player player;
    // Start is called before the first frame update
    void Start()
    { //set variables on start
        player = GameObject.Find("Player").GetComponent<Player>();
        thisTransform = GetComponent<Transform>();
        hpStone = 3;   
    }

    // Update is called once per frame
    void Update()
    {       
        //if hp of stone is less or equal zero
        //set 2 rng variables
        //instantiate stone
        //depending on rng instantiate diamond and silver
        //set hp of stone back to 3
        //add velocity to instatiated object
        if (hpStone<=0)
        {
            int d = Random.Range(0, 10);
            int s = Random.Range(0, 5);
            Rigidbody2D rb;
           rb= Instantiate(stone,new Vector3(thisTransform.position.x,thisTransform.position.y,thisTransform.position.z-4), transform.rotation);
            if (d == 0)
            {
                rb = Instantiate(diamond, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
            }
            if (s == 0)
            {
                rb = Instantiate(silver, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
            }
            hpStone = 3;
            rb.velocity = transform.TransformDirection(Vector3.down * 10);
        }
    }
    //function responsible for acquiring dmg

    public void TakeDmg(int dmg)
    {
        hpStone -= dmg;
    }
}

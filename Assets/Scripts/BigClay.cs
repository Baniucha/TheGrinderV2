using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT RESPONSIBLE FOR CLAY
public class BigClay : MonoBehaviour
{
    //variables
    public int hpClay = 3;
    public PlayerAttack playerDmg;
    public Rigidbody2D clay;
    public Rigidbody2D brick;

    public Rigidbody2D bigCoin;
    Transform thisTransform;
    // Start is called before the first frame update
    void Start()
    {
        //set variables on start
        thisTransform = GetComponent<Transform>();
        hpClay = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //if hp of clay is less or equal zero
        //set 2 rng variables
        //instantiate clay
        //depending on rng instantiate brick and big coin
        //set hp of clay back to 3
        //add velocity to instatiated object
        if (hpClay <= 0)
        {
            int r = Random.Range(0, 2);
            int c = Random.Range(0, 10);
            Rigidbody2D rb;
            rb = Instantiate(clay, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
            if (r == 0)
            {
                rb = Instantiate(brick, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
            }
            if(c==0)
            {
                rb = Instantiate(bigCoin, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
            }
            hpClay = 3;
            rb.velocity = transform.TransformDirection(Vector3.up * 10);
        }
    }
    //function responsible for acquiring dmg
    public void TakeDmg(int dmg)
    {
        hpClay -= dmg;
    }
}

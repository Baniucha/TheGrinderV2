using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SCRIPT RESPONSIBLE FOR SAND
public class BigSand : MonoBehaviour
{
    //variables
    public int hpSand = 3;
    public PlayerAttack playerDmg;
    public Rigidbody2D sand;
    public Rigidbody2D sandStone;

    public Rigidbody2D bigCoin;
    Transform thisTransform;
    // Start is called before the first frame update
    void Start()
    { //set variables on start
        thisTransform = GetComponent<Transform>();
        hpSand = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //if object's tag is different than SpecialSand

        //if hp of sand is less or equal zero
        //set 1 rng variable
        //instantiate sand
        //depending on rng instantiate sandstone
        //set hp of sand back to 3
        //add velocity to instatiated object
        if (this.gameObject.tag != "SpecialSand")
        {
            if (hpSand <= 0)
            {
                int r = Random.Range(0, 2);
                Rigidbody2D rb;
                rb = Instantiate(sand, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                if(r==0)
                {
                    rb = Instantiate(sandStone, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                }
                hpSand = 3;
                rb.velocity = transform.TransformDirection(Vector3.up * 10);
            }
        }
        //if object has tag SpecialSand
        //if hp of sand is less or equal 0
        //set 1 rng variable
        //instantiate sand
        //depending on rng instantiate big coing object
        //set hp of sand back to 3
        //set velocity to instantiated object
        else
        {
            if (hpSand <= 0)
            {
                int r = Random.Range(0, 10);
                Rigidbody2D rb;
                rb = Instantiate(sand, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                if(r==0)
                {
                    rb = Instantiate(bigCoin, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                }
                hpSand = 3;
                rb.velocity = transform.TransformDirection(Vector3.up * 10);
            }
        }
    }
    //fucntion responsible for acquring dmg
    public void TakeDmg(int dmg)
    {
        hpSand -= dmg;
    }
}

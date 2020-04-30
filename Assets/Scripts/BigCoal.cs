using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SCRIPT RESPONSIBLE FOR COAL

public class BigCoal : MonoBehaviour
{
    //VARIABLES
    public int hpCoal = 5;
    public PlayerAttack playerDmg;
    public Rigidbody2D coal;
    public Rigidbody2D iron;
    public Rigidbody2D diamond;
    public Rigidbody2D silver;
    public Rigidbody2D bigCoin;
    Transform thisTransform;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        //SET VARIABLES ON START
        player = GameObject.Find("Player").GetComponent<Player>();
        thisTransform = GetComponent<Transform>();
        hpCoal = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //if object has tag SpecialCoal
        //if hp of coal is less or equal 0
        //set 3 rng variables
        //instantiate coal 
        //depending on rng instantiate iron, diamond and silver object
        //set hp of coal back to 5
        //set velocity to instantiated object
        if (this.gameObject.tag == "SpecialCoal")
        {
            if (hpCoal <= 0)
            {
                int r = Random.Range(0, 2);
                int d = Random.Range(0, 10);
                int s = Random.Range(0, 5);
                Rigidbody2D rb;
                rb = Instantiate(coal, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                if (r == 0)
                {
                    rb = Instantiate(iron, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                }
                if (d == 0)
                {
                    rb = Instantiate(diamond, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                }
                if (s == 0)
                {
                    rb = Instantiate(silver, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                }
                hpCoal = 5;
                rb.velocity = transform.TransformDirection(Vector3.up * 10);
            }
        }
        //if object has tag SuperpecialCoal
        //if hp of coal is less or equal 0
        //set 2 rng variables
        //instantiate coal and iron twice
        //depending on rng instantiate big diamond and silver object
        //set hp of coal back to 5
        //set velocity to instantiated object
        else if (this.gameObject.tag == "SuperSpecialCoal")
        {
            if (hpCoal <= 0)
            {
                int d = Random.Range(0, 10);
                int s = Random.Range(0, 5);
                Rigidbody2D rb;
                rb = Instantiate(coal, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                rb = Instantiate(iron, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                rb = Instantiate(coal, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                rb = Instantiate(iron, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                if (d == 0)
                {
                    rb = Instantiate(diamond, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                }
                if (s == 0)
                {
                    rb = Instantiate(silver, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                }
                hpCoal = 5;
                rb.velocity = transform.TransformDirection(Vector3.up * 10);
            }
        }
    }    
    
    //fucntion responsible for acquring dmg
    public void TakeDmg(int dmg)
    {
        hpCoal -= dmg;
    }
}

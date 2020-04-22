using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSand : MonoBehaviour
{
    public int hpSand = 3;
    public PlayerAttack playerDmg;
    public Rigidbody2D sand;
    public Rigidbody2D sandStone;

    public Rigidbody2D bigCoin;
    Transform thisTransform;
    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
        hpSand = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag != "SpecialSand")
        {
            if (hpSand <= 0)
            {
                int r = Random.Range(0, 10);
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
        else
        {
            if (hpSand <= 0)
            {
                int r = Random.Range(0, 1);
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
    public void TakeDmg(int dmg)
    {
        hpSand -= dmg;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCoal : MonoBehaviour
{
    public int hpCoal = 5;
    public PlayerAttack playerDmg;
    public Rigidbody2D coal;
    public Rigidbody2D iron;

    public Rigidbody2D bigCoin;
    Transform thisTransform;
    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
        hpCoal = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "SpecialCoal")
        {
            if (hpCoal <= 0)
            {
                int r = Random.Range(0, 2);
                Rigidbody2D rb;
                rb = Instantiate(coal, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                if (r == 0)
                {
                    rb = Instantiate(iron, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                }
                hpCoal = 5;
                rb.velocity = transform.TransformDirection(Vector3.up * 10);
            }
        }
        else if (this.gameObject.tag == "SuperSpecialCoal")
        {
            if (hpCoal <= 0)
            {
                Rigidbody2D rb;
                rb = Instantiate(coal, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                rb = Instantiate(iron, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                rb = Instantiate(coal, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                rb = Instantiate(iron, new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z - 2), transform.rotation);
                hpCoal = 5;
                rb.velocity = transform.TransformDirection(Vector3.up * 10);
            }
        }
    }
    public void TakeDmg(int dmg)
    {
        hpCoal -= dmg;
    }
}

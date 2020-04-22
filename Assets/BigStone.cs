using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigStone : MonoBehaviour
{
    public int hpStone = 3;
    public PlayerAttack playerDmg;
    public Rigidbody2D stone;
    Transform thisTransform;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
        hpStone = 3;   
    }

    // Update is called once per frame
    void Update()
    {
        if(hpStone<=0)
        {
            Rigidbody2D rb;
           rb= Instantiate(stone,new Vector3(thisTransform.position.x,thisTransform.position.y,thisTransform.position.z-2), transform.rotation);
            hpStone = 3;
            rb.velocity = transform.TransformDirection(Vector3.up * 10);
        }
    }
    public void TakeDmg(int dmg)
    {
        hpStone -= dmg;
    }
}

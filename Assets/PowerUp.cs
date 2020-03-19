using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool doubleJump;
    // Start is called before the first frame update
    void Start()
    {
        doubleJump = false;
        if (this.tag == "DoubleJump") 
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            doubleJump = true;

        }
    }

    IEnumerator DoubleJump()
    {
        doubleJump = true;
        yield return new WaitForSeconds(5);
        doubleJump = false;
        StopCoroutine("DoubleJump");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

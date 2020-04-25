using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalGround : MonoBehaviour
{
    public bool c1, c2, c3;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("C1"))
        {
            c1 = true;
        }
        if (other.CompareTag("C2"))
        {
            c2 = true;
        }
        if (other.CompareTag("C3"))
        {
            c3 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("C1"))
        {
            c1 = false ;
        }
        if (collision.CompareTag("C2"))
        {
            c2 = false;
        }
        if (collision.CompareTag("C3"))
        {
            c3 = false;
        }
    }
}

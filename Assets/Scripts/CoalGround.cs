using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT RESPONSIBLE ON PLAYER'S POSITION ON COAL GROUND
//DEPENDING WHICH VARIABLE IS SET TO TRUE
//ENEMIES ON COAL GROUND WILL MOVE TO DIFFERENT POSITIONS
public class CoalGround : MonoBehaviour
{
    public bool c1, c2, c3;

    //SET VARABILES TO TRUE ON ENTER
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

    //SET VARIABLES TO FALSE ON EXIT
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

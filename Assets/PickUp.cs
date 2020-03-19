using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")&& this.CompareTag("Wood"))
        {
            item.woodAmount++;
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Player") && this.CompareTag("Stone"))
        {
            item.stoneAmount++;
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Player") && this.CompareTag("Sand"))
        {
            item.sandAmount++;
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        if(item.stoneAmount<0)
        {
            item.stoneAmount = 0;
        }
        if (item.woodAmount < 0)
        {
            item.woodAmount = 0;
        }
      
    }
}

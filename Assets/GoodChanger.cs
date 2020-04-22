using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoodChanger : MonoBehaviour
{
    public GameObject goodChangerUI;
    public TextMeshProUGUI textNotEnough;
    public Item itemRef;
    public Player player;
    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        textNotEnough.text = "Not Enough goods";
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            goodChangerUI.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            goodChangerUI.SetActive(false);
        }

    }
    public void Sand()
    {
        if(itemRef.woodAmount>0 && itemRef.stoneAmount>0)
        {
            itemRef.woodAmount -= 2;
            itemRef.stoneAmount -= 2;
            itemRef.sandAmount++;
        }
        else
        {
            textNotEnough.gameObject.SetActive(true);
        }
    }
    public void SandStone()
    {
        if (itemRef.woodAmount > 0 && itemRef.stoneAmount > 0)
        {
            itemRef.woodAmount -= 2;
            itemRef.stoneAmount -= 2;
            itemRef.sandstoneAmount++;
        }
        else
        {
            textNotEnough.gameObject.SetActive(true);
        }
    }
    public void Clay()
    {
        if (itemRef.sandAmount > 0 && itemRef.sandstoneAmount> 0)
        {
            itemRef.sandAmount -= 2;
            itemRef.sandstoneAmount -= 2;
            itemRef.clayAmount++;
        }
        else
        {
            textNotEnough.gameObject.SetActive(true);
        }
    }
    public void Brick()
    {
        if (itemRef.sandAmount > 0 && itemRef.sandstoneAmount > 0)
        {
            itemRef.sandAmount -= 2;
            itemRef.sandstoneAmount -= 2;
            itemRef.brickAmount++;
        }
        else
        {
            textNotEnough.gameObject.SetActive(true);
        }
    }
    public void Coal()
    {
        if (itemRef.brickAmount > 0 && itemRef.clayAmount > 0)
        {
            itemRef.brickAmount -= 2;
            itemRef.clayAmount -= 2;
            itemRef.coalAmount++;
        }
        else
        {
            textNotEnough.gameObject.SetActive(true);
        }
    }
    public void Iron()
    {
        if (itemRef.brickAmount > 0 && itemRef.clayAmount > 0)
        {
            itemRef.brickAmount -= 2;
            itemRef.clayAmount -= 2;
            itemRef.ironAmount++;
        }
        else
        {
            textNotEnough.gameObject.SetActive(true);
        }
    }
    public void HP()
    {
        if(player.actualHealth <player.maxHealth)
        {
            itemRef.coin -= 50;
            player.actualHealth += 25;
            if(player.actualHealth>player.maxHealth)
            {
                player.actualHealth = player.maxHealth;
            }
        }
    }
}

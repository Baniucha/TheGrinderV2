using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ToolShop : MonoBehaviour
{
    public GameObject toolUI;
    public Item ItemRef;
    public TextMeshProUGUI text;
    public bool iHavePickaxe, iHaveAxe, iHaveShovel;
    private void Start()
    {
        text.text = " ";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            toolUI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            toolUI.SetActive(false);
        }
    }

    public void BuyAxe()
    {
        if(ItemRef.coin>=25)
        {
            ItemRef.coin -= 25;
            text.text = "You bought axe";
            iHaveAxe = true;
        }
        else
        {
            text.text = "You don't have enough coins";
        }
    }
    public void BuyPickAxe()
    {
        if (ItemRef.coin >= 25)
        {
            ItemRef.coin -= 25;
            text.text = "You bought pickaxe";
            iHavePickaxe = true;
        }
        else
        {
            text.text = "You don't have enough coins";
        }
    }
    public void BuyShovel()
    {
        if (ItemRef.coin >= 25)
        {
            ItemRef.coin -= 25;
            text.text = "You bought shovel";
            iHaveShovel = true;
        }
        else
        {
            text.text = "You don't have enough coins";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//SCRIPT RESPONSBILE FOR TOOL SHOP
public class ToolShop : MonoBehaviour
{

    //VARIABLES
    public GameObject toolUI;
    public Item ItemRef;
    public TextMeshProUGUI text;
    public bool iHavePickaxe, iHaveAxe, iHaveShovel;
    private void Start()
    {
        //SET TEXT
        text.text = " ";
    }

    //IF PLAYER COLLIDES WITH TOOL SHOP
    //ENABLE TOOL SHOP UI
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            toolUI.SetActive(true);
        }
    }
    //IF PLAYER LEAVES COLLIDER
    //DISABLE TOOL SHOP UI
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            toolUI.SetActive(false);
        }
    }

    //FUNCTIONS RESPONSIBLE FOR BUYING TOOLS
    //SUBTRACT COINS AND GIVE TOOLS
    //IF NOT ENOUGH MONEY DISPLAY INFORMATION
    public void BuyAxe()
    {
        if (!iHaveAxe)
        {
            if (ItemRef.coin >= 25)
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
    }
    public void BuyPickAxe()
    {
        if (!iHavePickaxe)
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
    }
    public void BuyShovel()
    {
        if (!iHaveShovel)
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
}

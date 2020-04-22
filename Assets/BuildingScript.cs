using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingScript : MonoBehaviour
{
    public Item itemRef;
    public GameObject alchemistUI, blacksmithUI;
    int cost1000 = 1000;
    int cost2000 = 2000;
    int cost3000 = 3000;
    public TextMeshProUGUI textNotEnoughAlchemist, textNotEnoughBlacksmith;
    public GameObject textHelloAlchemist, textHelloBlacksmith;
    public Player playerRef;
    public PlayerAttack playerAttackRef;
    public GameObject button1, button2, button3, button4;
    public GameObject button5, button6, button7, button8;
    public GameObject alchemistPanel,blacksmithPanel;
    bool dontShowAlchemist, dontShowBlacksmith;
    private void Start()
    {
        dontShowAlchemist = dontShowBlacksmith = false;
        alchemistUI.SetActive(false);
        textNotEnoughAlchemist.gameObject.SetActive(false);
        textNotEnoughAlchemist.text = "You don't have enough coins";
        textNotEnoughBlacksmith.gameObject.SetActive(false);
        textNotEnoughBlacksmith.text = "You don't have enough coins";

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.tag == "Alchemist" && other.CompareTag("Player")&&!dontShowAlchemist)
        {

            alchemistUI.SetActive(true);
        }
        if (this.tag == "Blacksmith" && other.CompareTag("Player")&&!dontShowBlacksmith)
        {
            blacksmithUI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.tag == "Alchemist" && collision.CompareTag("Player"))
        {
            textNotEnoughAlchemist.gameObject.SetActive(false);
            alchemistUI.SetActive(false);
        }
        if (this.tag == "Blacksmith" && collision.CompareTag("Player"))
        {
            textNotEnoughBlacksmith.gameObject.SetActive(false);
            blacksmithUI.SetActive(false);
        }
    }

    public void Alchemist1()
    {
        if(itemRef.coin>=cost1000)
        {
            Destroy(button1);
            itemRef.coin -= cost1000;
            playerRef.maxHealth += 10;
            if (alchemistPanel.transform.childCount < 3)
            {
                Destroy(alchemistPanel);
                dontShowAlchemist = true;
            }
        }
        else
        {
            textHelloAlchemist.SetActive(false);
            textNotEnoughAlchemist.gameObject.SetActive(true);
        }
    }
    public void Alchemist2()
    {
        if (itemRef.coin >= cost1000)
        {
            Destroy(button2);
            itemRef.coin -= cost1000;
            playerRef.maxHealth += 10;
            if (alchemistPanel.transform.childCount < 3)
            {
                Destroy(alchemistPanel);
                dontShowAlchemist = true;
            }
        }
        else
        {
            textHelloAlchemist.SetActive(false);
            textNotEnoughAlchemist.gameObject.SetActive(true);
        }
    }
    public void Alchemist3()
    {
        if (itemRef.coin >= cost2000)
        {
            Destroy(button3);
            itemRef.coin -= cost2000;
            playerRef.maxHealth += 10;
            if (alchemistPanel.transform.childCount < 3)
            {
                Destroy(alchemistPanel);
                dontShowAlchemist = true;
            }
        }
        else
        {
            textHelloAlchemist.SetActive(false);
            textNotEnoughAlchemist.gameObject.SetActive(true);
        }
    }
    public void Alchemist4()
    {
        if (itemRef.coin >= cost3000)
        {
            Destroy(button4);
            itemRef.coin -= cost3000;
            playerRef.maxHealth += 20;
            if(alchemistPanel.transform.childCount<3)
            {
                Destroy(alchemistPanel);
                dontShowAlchemist = true;
            }
        }
        else
        {
            textHelloAlchemist.SetActive(false);
            textNotEnoughAlchemist.gameObject.SetActive(true);
        }
    }
    public void Blacksmith1()
    {
        if (itemRef.coin >= cost1000)
        {
            Destroy(button5);
            itemRef.coin -= cost1000;
            playerAttackRef.dmg += 1;
            if (blacksmithPanel.transform.childCount < 3)
            {
                Destroy(blacksmithPanel);
                dontShowBlacksmith = true;
            }
        }
        else
        {
            textHelloBlacksmith.SetActive(false);
            textNotEnoughBlacksmith.gameObject.SetActive(true);
        }
    }
    public void Blacksmith2()
    {
        if (itemRef.coin >= cost1000)
        {
            Destroy(button6);
            itemRef.coin -= cost1000;
            playerAttackRef.dmg += 1;
            if (blacksmithPanel.transform.childCount < 3)
            {
                Destroy(blacksmithPanel);
                dontShowBlacksmith = true;
            }
        }
        else
        {
            textHelloBlacksmith.SetActive(false);
            textNotEnoughBlacksmith.gameObject.SetActive(true);
        }
    }
    public void Blacksmith3()
    {
        if (itemRef.coin >= cost2000)
        {
            Destroy(button7);
            itemRef.coin -= cost2000;
            playerAttackRef.dmg+= 1;
            if (blacksmithPanel.transform.childCount < 3)
            {
                Destroy(blacksmithPanel);
                dontShowBlacksmith = true;
            }
        }
        else
        {
            textHelloBlacksmith.SetActive(false);
            textNotEnoughBlacksmith.gameObject.SetActive(true);
        }
    }
    public void Blacksmith4()
    {
        if (itemRef.coin >= cost3000)
        {
            Destroy(button8);
            itemRef.coin -= cost3000;
            playerAttackRef.dmg += 2;
            if (blacksmithPanel.transform.childCount < 3)
            {
                Destroy(blacksmithPanel);
                dontShowBlacksmith = true;
            }
        }
        else
        {
            textHelloBlacksmith.SetActive(false);
            textNotEnoughBlacksmith.gameObject.SetActive(true);
        }
    }
}

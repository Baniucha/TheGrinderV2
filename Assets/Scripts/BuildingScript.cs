using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//SCRIPT RESPONSIBLE FOR BUILDINGS
public class BuildingScript : MonoBehaviour
{
    //VARIABLES
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
    public GameObject hpButton;
    bool dontShowAlchemist, dontShowBlacksmith;
    private void Start()
    {
        //SET VARIABLES
        dontShowAlchemist = dontShowBlacksmith = false;
        alchemistUI.SetActive(false);
        textNotEnoughAlchemist.gameObject.SetActive(false);
        textNotEnoughAlchemist.text = "You don't have enough coins";
        textNotEnoughBlacksmith.gameObject.SetActive(false);
        textNotEnoughBlacksmith.text = "You don't have enough coins";

    }

    //DEPENDING ON OBJECT'S TAG ENABLE DIFFERENT UIS
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
    //DEPENDING ON OBJECT'S TAG DISABLE DIFFERENT UIS

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

    //ALCHEMIST FUNCTION
    //IF PLAYER HAS MORE THAN 1000 COINS
    //DESTROY BUTTON SO PLAYER CANNOT BUY IT AGAIN
    //SUBTRACT 1000 COINS
    //ADD 10 TO MAX PLAYER'SH HEALTH
    //IF OBJECT PANEL HAS LESS THAN 3 CHILDREN
    //DESTROY PANEL AND DISABLE POSSIBILITY TO DISPLAY IT IN THE FUTURE

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
    //ALCHEMIST FUNCTION
    //IF PLAYER HAS MORE THAN 1000 COINS
    //DESTROY BUTTON SO PLAYER CANNOT BUY IT AGAIN
    //SUBTRACT 1000 COINS
    //ADD 10 TO MAX PLAYER'SH HEALTH
    //IF OBJECT PANEL HAS LESS THAN 3 CHILDREN
    //DESTROY PANEL AND DISABLE POSSIBILITY TO DISPLAY IT IN THE FUTURE
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
    //ALCHEMIST FUNCTION
    //IF PLAYER HAS MORE THAN 2000 COINS
    //DESTROY BUTTON SO PLAYER CANNOT BUY IT AGAIN
    //SUBTRACT 2000 COINS
    //ADD 10 TO MAX PLAYER'SH HEALTH
    //IF OBJECT PANEL HAS LESS THAN 3 CHILDREN
    //DESTROY PANEL AND DISABLE POSSIBILITY TO DISPLAY IT IN THE FUTURE
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
    //ALCHEMIST FUNCTION
    //IF PLAYER HAS MORE THAN 3000 COINS
    //DESTROY BUTTON SO PLAYER CANNOT BUY IT AGAIN
    //SUBTRACT 3000 COINS
    //ADD 20 TO MAX PLAYER'SH HEALTH
    //IF OBJECT PANEL HAS LESS THAN 3 CHILDREN
    //DESTROY PANEL AND DISABLE POSSIBILITY TO DISPLAY IT IN THE FUTURE
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
    //FUNCTION REPSONIBLE FOR FILLING HP BACK TO MAX
    public void AlchemistHP()
    {
        if (playerRef.actualHealth != playerRef.maxHealth)
        {
            if (itemRef.coin >= 100)
            {
                itemRef.coin -= 100;
                playerRef.actualHealth = playerRef.maxHealth;

            }
            else
            {
                textHelloAlchemist.SetActive(false);
                textNotEnoughAlchemist.gameObject.SetActive(true);
            }
        }
    }
    //BLACKSMITH FUNCTION
    //IF PLAYER HAS MORE THAN 1000 COINS
    //DESTROY BUTTON SO PLAYER CANNOT BUY IT AGAIN
    //SUBTRACT 1000 COINS
    //ADD 1 TO PLAYER'S DMG
    //IF OBJECT PANEL HAS LESS THAN 3 CHILDREN
    //DESTROY PANEL AND DISABLE POSSIBILITY TO DISPLAY IT IN THE FUTURE
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
    //BLACKSMITH FUNCTION
    //IF PLAYER HAS MORE THAN 1000 COINS
    //DESTROY BUTTON SO PLAYER CANNOT BUY IT AGAIN
    //SUBTRACT 1000 COINS
    //ADD 1 TO PLAYER'S DMG
    //IF OBJECT PANEL HAS LESS THAN 3 CHILDREN
    //DESTROY PANEL AND DISABLE POSSIBILITY TO DISPLAY IT IN THE FUTURE
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
    //BLACKSMITH FUNCTION
    //IF PLAYER HAS MORE THAN 2000 COINS
    //DESTROY BUTTON SO PLAYER CANNOT BUY IT AGAIN
    //SUBTRACT 2000 COINS
    //ADD 1 TO PLAYER'S DMG
    //IF OBJECT PANEL HAS LESS THAN 3 CHILDREN
    //DESTROY PANEL AND DISABLE POSSIBILITY TO DISPLAY IT IN THE FUTURE
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

    //BLACKSMITH FUNCTION
    //IF PLAYER HAS MORE THAN 3000 COINS
    //DESTROY BUTTON SO PLAYER CANNOT BUY IT AGAIN
    //SUBTRACT 3000 COINS
    //ADD 2 TO PLAYER'S DMG
    //IF OBJECT PANEL HAS LESS THAN 3 CHILDREN
    //DESTROY PANEL AND DISABLE POSSIBILITY TO DISPLAY IT IN THE FUTURE
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

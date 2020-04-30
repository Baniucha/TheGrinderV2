using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//SCRIPT RESPONSIBLE FOR BASE
public class baseScript : MonoBehaviour
{
    //variables
    public Item itemRef;
    public GameObject canvas,canvasUpgradeLvl2,canvasUpgradeLvl3, canvasUpgradeLvl4,canvasUpgradeLvl5, baseLvl2, baseLvl3, baseLvl4, baseLvl5, gameOverEffect;
    public bool ReadyForlvlbase2, ReadyForlvlbase3, ReadyForlvlbase4, ReadyForlvlbase5;
    public bool ReadyForlvlbaseUpgrade2, ReadyForlvlbaseUpgrade3, ReadyForlvlbaseUpgrade4, ReadyForlvlbaseUpgrade5;
    public bool woodUpgraded, stoneUpgraded, sandUpgraded, good2Upgraded, lvl3Good1Upgraded, lvl3Good2Upgraded, lvl4Good1Upgraded, lvl4Good2Upgraded;
    bool doNotBuild;
    public displayText textRef;
    public TextMeshProUGUI gameover;


    // Start is called before the first frame update
    void Start()
    {
        //set variables on start


        gameOverEffect.SetActive(false);
        gameover.gameObject.SetActive(false);
        //Booleans for gameobject
        baseLvl2.SetActive(false);
        baseLvl3.SetActive(false);
        baseLvl4.SetActive(false);
        baseLvl5.SetActive(false);


        ReadyForlvlbase2 = true;
        ReadyForlvlbase3 = false;
        ReadyForlvlbase4 = false;
        ReadyForlvlbase5 = false;

        doNotBuild = false;

        canvas.SetActive(false);
        woodUpgraded = stoneUpgraded = sandUpgraded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        //depending on what lvl is base
        //display differen information
        if (other.CompareTag("Player") && !doNotBuild)
        {
            if (other.CompareTag("Player") && ReadyForlvlbaseUpgrade2)
            {
                canvasUpgradeLvl2.SetActive(true);
            }
            else if (other.CompareTag("Player") && ReadyForlvlbaseUpgrade3)
            {
                canvasUpgradeLvl3.SetActive(true);
            }
            else if (other.CompareTag("Player") && ReadyForlvlbaseUpgrade4)
            {
                canvasUpgradeLvl4.SetActive(true);
            }
            else if (other.CompareTag("Player") && ReadyForlvlbaseUpgrade5)
            {
                canvasUpgradeLvl5.SetActive(true);
            }
            else if (other.CompareTag("Player"))
            {
                textRef.text.text = "Do you want to build it?";
                canvas.SetActive(true);
            }
        }

    }

    //disable when player leaves 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(false);
            canvasUpgradeLvl2.SetActive(false);
            canvasUpgradeLvl3.SetActive(false);
            canvasUpgradeLvl4.SetActive(false);
            canvasUpgradeLvl5.SetActive(false);

        }
    }

    //Below functions that allow player to upgrade base to different lvls with different costs 
    public void BuildToLvl2()
    {

        if (ReadyForlvlbase2 && itemRef.woodAmount >= 10 && itemRef.stoneAmount >= 10)
        {
            itemRef.woodAmount -= 10;
            itemRef.stoneAmount -= 10;
            baseLvl2.SetActive(true);
            ReadyForlvlbase2 = false;
            ReadyForlvlbaseUpgrade2 = true;
            canvas.SetActive(false);
        }

  //Not enough Resources
        else if ( itemRef.woodAmount < 10 || itemRef.stoneAmount < 10)
        {
            textRef.text.text = "Not enough resources";
        }     
    }
    public void BuildToLvl3()
    {
        if (ReadyForlvlbase3 && itemRef.woodAmount >= 20 && itemRef.stoneAmount >= 20&& itemRef.sandAmount>=10&&itemRef.sandstoneAmount>=10)
        {
            itemRef.woodAmount -= 20;
            itemRef.stoneAmount -= 20;
            itemRef.sandAmount -= 10;
            itemRef.sandstoneAmount -= 10;


            baseLvl3.SetActive(true);
            ReadyForlvlbase3 = false;
            ReadyForlvlbaseUpgrade3 = true;
            canvas.SetActive(false);
        }

        //Not enough Resources
        else if (itemRef.woodAmount < 20 || itemRef.stoneAmount < 20 || itemRef.sandAmount < 10 || itemRef.sandstoneAmount < 10)
        {
            textRef.text.text = "Not enough resources";
        }
    }
    public void BuildToLvl4()
    {
        if (ReadyForlvlbase4 && itemRef.clayAmount >= 10 && itemRef.brickAmount>=10 && itemRef.sandAmount >= 20 && itemRef.sandstoneAmount >= 20)
        {
            itemRef.clayAmount -= 10;
            itemRef.brickAmount -= 10;
            itemRef.sandAmount -= 20;
            itemRef.sandstoneAmount -= 20;


            baseLvl4.SetActive(true);
            ReadyForlvlbase4 = false;
            ReadyForlvlbaseUpgrade4 = true;
            canvas.SetActive(false);
        }

        //Not enough Resources
        else if (itemRef.clayAmount < 10 || itemRef.brickAmount< 10 || itemRef.sandAmount < 20 || itemRef.sandstoneAmount < 20)
        {
            textRef.text.text = "Not enough resources";
        }
    }
    public void BuildToLvl5()
    {
        if (ReadyForlvlbase5 && itemRef.ironAmount >= 10 && itemRef.coalAmount>= 10 && itemRef.clayAmount>= 20 && itemRef.brickAmount>= 20)
        {
            itemRef.ironAmount -= 10;
            itemRef.coalAmount -= 10;
            itemRef.clayAmount -= 20;
            itemRef.brickAmount -= 20;


            baseLvl2.SetActive(false);
            baseLvl3.SetActive(false);
            baseLvl4.SetActive(false);
            baseLvl5.SetActive(true);
            ReadyForlvlbase5 = false;
            ReadyForlvlbaseUpgrade5 = true;
            canvas.SetActive(false);
            gameover.gameObject.SetActive(true);
            gameOverEffect.SetActive(true);
        }

        //Not enough Resources
        else if (itemRef.clayAmount < 10|| itemRef.brickAmount < 10 || itemRef.coalAmount < 20 || itemRef.ironAmount < 20)
        {
            textRef.text.text = "Not enough resources";
        }
    }
    //Set canvas to not active
    public void DontBuild()
    {
        canvas.SetActive(false);
        canvasUpgradeLvl2.SetActive(false);
        canvasUpgradeLvl3.SetActive(false);
        canvasUpgradeLvl4.SetActive(false);
        canvasUpgradeLvl5.SetActive(false);
    }

    //Display information depending on what level the base is 
    //and inform player what are the options for upgrade
    public void ChangeText()
    {
        if (ReadyForlvlbaseUpgrade2)
        {
            textRef.text.text = textRef.upgradeYourBase.ToString();
            textRef.btnText1.text = "Wood";
            textRef.btnText2.text = "Stone";
        }
        else if (ReadyForlvlbase3)
        {
            textRef.text.text = textRef.upgradeYourBase.ToString();
            textRef.btnText1.text = "Sand";
            textRef.btnText2.text = "Good1";
        }
        else if(ReadyForlvlbase4)
        {
            textRef.text.text = textRef.upgradeYourBase.ToString();
            textRef.btnText1.text = "Good41";
            textRef.btnText2.text = "Good42";
        }
        else if (ReadyForlvlbase5)
        {
            textRef.text.text = textRef.upgradeYourBase.ToString();
            textRef.btnText1.text = "Good51";
            textRef.btnText2.text = "Good52";
        }
        if (!ReadyForlvlbaseUpgrade2 && !ReadyForlvlbaseUpgrade3 && !ReadyForlvlbaseUpgrade4 && !ReadyForlvlbaseUpgrade5)
        {
            textRef.text.text = textRef.doYouWannaBuildIt;
            textRef.btnText1.text = textRef.yes.ToString();
            textRef.btnText2.text = textRef.no.ToString();
        }
    }

    //Below there are functions that upgrade goods and set them to increase automatically
    public void UpgradeWood()
    {
        if (itemRef.woodAmount >= 25 && itemRef.stoneAmount >= 50)
        {
            
            itemRef.woodAmount -= 15;
            itemRef.stoneAmount -= 5;
            ReadyForlvlbaseUpgrade2 = false;
            woodUpgraded = true;
            ReadyForlvlbase3 = true;
            canvasUpgradeLvl2.SetActive(false);
        }
    }
    public void UpgradeStone()
    {
        if (itemRef.woodAmount >= 25 && itemRef.stoneAmount >= 50)
        {
            itemRef.woodAmount -= 5;
            itemRef.stoneAmount -= 15;
            ReadyForlvlbaseUpgrade2 = false;
            stoneUpgraded = true;
            ReadyForlvlbase3 = true;
            canvasUpgradeLvl2.SetActive(false);
        }
    }
    public void UpgradeSand()
    {
        if (itemRef.sandAmount >= 15 && itemRef.sandstoneAmount >= 45)
        {

            itemRef.sandAmount-= 15;
            itemRef.sandstoneAmount -= 5;
            ReadyForlvlbaseUpgrade3 = false;
            sandUpgraded = true;
            ReadyForlvlbase4 = true;
            canvasUpgradeLvl3.SetActive(false);

        }
    }
    public void UpgradeGood2Lvl2()
    {
        if (itemRef.sandAmount >= 15 && itemRef.sandstoneAmount >= 45)
        {

            itemRef.sandAmount -= 5;
            itemRef.sandstoneAmount -= 15;
            ReadyForlvlbaseUpgrade3 = false;
            good2Upgraded = true;
            ReadyForlvlbase4 = true;
            canvasUpgradeLvl3.SetActive(false);

        }
    }
    public void UpgradeGood3Lvl1()
    {
        if (itemRef.clayAmount >= 10 && itemRef.brickAmount >= 30)
        {

            itemRef.clayAmount -= 10;
            itemRef.brickAmount -= 30;
            ReadyForlvlbaseUpgrade4 = false;
            lvl3Good1Upgraded = true;
            ReadyForlvlbase5 = true;
            canvasUpgradeLvl4.SetActive(false);

        }
    }
    public void UpgradeGood3Lvl2()
    {
        if (itemRef.brickAmount >= 10 && itemRef.clayAmount >= 30)
        {

            itemRef.brickAmount -= 10;
            itemRef.clayAmount -= 30;
            ReadyForlvlbaseUpgrade4 = false;
            lvl3Good2Upgraded = true;
            ReadyForlvlbase5 = true;
            canvasUpgradeLvl4.SetActive(false);

        }
    }
    public void UpgradeGood4Lvl1()
    {
        if (itemRef.ironAmount >= 15 && itemRef.coalAmount >= 5)
        {

            itemRef.coalAmount -= 5;
            itemRef.ironAmount -= 15;
            ReadyForlvlbaseUpgrade4 = false;
            lvl4Good1Upgraded = true;
            ReadyForlvlbase5 = true;
            canvasUpgradeLvl5.SetActive(false);
            this.GetComponent<baseScript>().enabled = false;
            doNotBuild = true;

        }
    }
    public void UpgradeGood4Lvl2()
    {
        if (itemRef.clayAmount >= 5 && itemRef.brickAmount>= 15)
        {

            itemRef.clayAmount -= 5;
            itemRef.brickAmount -= 15;
            ReadyForlvlbaseUpgrade4 = false;
            lvl4Good2Upgraded = true;
            ReadyForlvlbase5 = true;
            canvasUpgradeLvl5.SetActive(false);
            this.GetComponent<baseScript>().enabled = false;
            doNotBuild = true;
        }
    }


}

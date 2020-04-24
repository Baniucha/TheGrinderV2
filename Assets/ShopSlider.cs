using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopSlider : MonoBehaviour
{
    public Item itemRef;
    public Slider sliderInstance;
    int valueFinal;
    public bool tester;
    public bool sellingWood, buyingWood;
    public bool sellindStone, buyingStone;
    public bool sellingSand, buyingSand;
    public bool selling1, buying1;
    public bool selling2, buying2;
    public bool selling3, buying3;
    public bool selling4, buying4;
    public bool selling5, buying5;
    public bool selling6, buying6;
    public bool selling7, buying7;
    public ShopScript goodRef;
    public GameObject shoopUi,goodUi;
    private void Start()
    {
        sellindStone = selling1 = selling2 = selling3 = selling4 = selling5 = selling6 = selling7 = sellingSand = sellingWood = false;
        buying1 = buying2 = buying3 = buying4 = buying5 = buyingSand = buyingStone = buyingWood = false;
        sliderInstance.minValue = 0;
        sliderInstance.maxValue = itemRef.woodAmount;
        sliderInstance.wholeNumbers = true;
        sliderInstance.value = 0;
        valueFinal = Mathf.FloorToInt(sliderInstance.value);
        
    }
    public void OnValueChanged()
    {
        valueFinal = (int)sliderInstance.value;

    }


    public void Wood()
    {
        sliderInstance.gameObject.SetActive(true);
        goodUi.SetActive(false);


        if (goodRef.isSelling)
        {
            sellingWood = true;
            //Ustawia liczbe tego gowna jebanego zasranego zeby to kurestwo dzialalo inaczej pierdole to
            //Najpierw kliknij wood, sand czy inne gowno i to sie ustawi
            //potem slidera ustawiasz zeby byl widoczny i tam robisz magie
            sliderInstance.maxValue = itemRef.woodAmount;
            valueFinal = (int)sliderInstance.value;
        }
        else if (goodRef.isBuying)
        {
            buyingWood = true;
            //buy stuff
            sliderInstance.maxValue = itemRef.coin;
            valueFinal = (int)sliderInstance.value;
        }
    }
    public void Stone()
    {
        sliderInstance.gameObject.SetActive(true);
        goodUi.SetActive(false);

        if (goodRef.isSelling)
        {
            sellindStone = true;
            sliderInstance.maxValue = itemRef.stoneAmount;
            valueFinal = (int)sliderInstance.value;
        }
        else if (goodRef.isBuying)
        {
            buyingStone = true;
            //buy stuff
            sliderInstance.maxValue = itemRef.coin;
            valueFinal = (int)sliderInstance.value;
        }
    }
    public void Good1()
    {
        sliderInstance.gameObject.SetActive(true);
        goodUi.SetActive(false);

        if (goodRef.isSelling)
        {
            selling1 = true;
            sliderInstance.maxValue = itemRef.sandstoneAmount;
            valueFinal = (int)sliderInstance.value;
        }
        else if (goodRef.isBuying)
        {
            buying1 = true;
            sliderInstance.maxValue = itemRef.coin;
            valueFinal = (int)sliderInstance.value;
        }
    }
    public void Sand()
    {
        sliderInstance.gameObject.SetActive(true);
        goodUi.SetActive(false);

        if (goodRef.isSelling)
        {
            sellingSand = true;
            sliderInstance.maxValue = itemRef.sandAmount;
            valueFinal = (int)sliderInstance.value;
        }
        else if (goodRef.isBuying)
        {
            buyingSand = true;
            sliderInstance.maxValue = itemRef.coin;
            valueFinal = (int)sliderInstance.value;
        }
    }
    public void Good2()
    {
        sliderInstance.gameObject.SetActive(true);
        goodUi.SetActive(false);

        if (goodRef.isSelling)
        {
            selling2 = true;
            sliderInstance.maxValue = itemRef.clayAmount;
            valueFinal = (int)sliderInstance.value;
        }
        else if (goodRef.isBuying)
        {
            buying2 = true;
            sliderInstance.maxValue = itemRef.coin;
            valueFinal = (int)sliderInstance.value;
        }
    }
    public void Good3()
    {
        sliderInstance.gameObject.SetActive(true);
        goodUi.SetActive(false);

        if (goodRef.isSelling)
        {
            selling3 = true;

            sliderInstance.maxValue = itemRef.brickAmount;
            valueFinal = (int)sliderInstance.value;
        }
        else if (goodRef.isBuying)
        {
            buying3 = true;
            sliderInstance.maxValue = itemRef.coin;
            valueFinal = (int)sliderInstance.value;
        }
    }
    public void Good4()
    {
        sliderInstance.gameObject.SetActive(true);
        goodUi.SetActive(false);

        if (goodRef.isSelling)
        {
            selling4 = true;
            sliderInstance.maxValue = itemRef.ironAmount;
            valueFinal = (int)sliderInstance.value;
        }
        else if (goodRef.isBuying)
        {
            buying4 = true;
            sliderInstance.maxValue = itemRef.coin;
            valueFinal = (int)sliderInstance.value;
        }
    }
    public void Good5()
    {
        sliderInstance.gameObject.SetActive(true);
        goodUi.SetActive(false);

        if (goodRef.isSelling)
        {
            selling5 = true;
            sliderInstance.maxValue = itemRef.coalAmount;
            valueFinal = (int)sliderInstance.value;
        }
        else if (goodRef.isBuying)
        {
            buying5 = true;
            sliderInstance.maxValue = itemRef.coin;
            valueFinal = (int)sliderInstance.value;
        }
    }
    public void Good6()
    {
        sliderInstance.gameObject.SetActive(true);
        goodUi.SetActive(false);

        if (goodRef.isSelling)
        {
            selling6 = true;
            sliderInstance.maxValue = itemRef.silverAmount;
            valueFinal = (int)sliderInstance.value;
        }
        else if (goodRef.isBuying)
        {
            buying6 = true;
            sliderInstance.maxValue = itemRef.coin;
            valueFinal = (int)sliderInstance.value;
        }
    }
    public void Good7()
    {
        sliderInstance.gameObject.SetActive(true);
        goodUi.SetActive(false);

        if (goodRef.isSelling)
        {
            selling7 = true;
            sliderInstance.maxValue = itemRef.diamondAmount;
            valueFinal = (int)sliderInstance.value;
        }
        else if (goodRef.isBuying)
        {
            buying7 = true;
            sliderInstance.maxValue = itemRef.coin;
            valueFinal = (int)sliderInstance.value;
        }
    }
    public void continueTest()
    {
        //chuj dziala nie ruszaj
        if (sellingWood && itemRef.woodAmount != 0)
        {
            itemRef.woodAmount -= valueFinal;
            itemRef.coin += valueFinal;
            shoopUi.SetActive(false);
        }
        else if (sellindStone && itemRef.stoneAmount != 0)
        {
            itemRef.stoneAmount -= valueFinal;
            itemRef.coin += valueFinal;
            shoopUi.SetActive(false);
        }
        else if (sellingSand && itemRef.sandAmount != 0)
        {
            itemRef.sandAmount -= valueFinal;
            itemRef.coin += valueFinal*2;
            shoopUi.SetActive(false);
        }
        else if (selling1 && itemRef.sandstoneAmount != 0)
        {
            itemRef.sandstoneAmount -= valueFinal;
            itemRef.coin += valueFinal*2;
            shoopUi.SetActive(false);
        }
        else if (selling2 && itemRef.clayAmount != 0)
        {
            itemRef.clayAmount -= valueFinal;
            itemRef.coin += valueFinal*3;
            shoopUi.SetActive(false);
        }
        else if (selling3 && itemRef.brickAmount!= 0)
        {
            itemRef.brickAmount -= valueFinal;
            itemRef.coin += valueFinal*3;
            shoopUi.SetActive(false);
        }
        else if (selling4 && itemRef.ironAmount!= 0)
        {
            itemRef.ironAmount -= valueFinal;
            itemRef.coin += valueFinal*5;
            shoopUi.SetActive(false);
        }
        else if (selling5 && itemRef.coalAmount!= 0)
        {
            itemRef.coalAmount -= valueFinal;
            itemRef.coin += valueFinal*5;
            shoopUi.SetActive(false);
        }
        else if (selling6 && itemRef.silverAmount!= 0)
        {
            itemRef.silverAmount -= valueFinal;
            itemRef.coin += valueFinal*8;
            shoopUi.SetActive(false);
        }
        else if (selling7&& itemRef.diamondAmount!= 0)
        {
            itemRef.diamondAmount -= valueFinal;
            itemRef.coin += valueFinal*8;
            shoopUi.SetActive(false);
        }
        //buying
        if(buyingWood&&itemRef.coin!=0)
        {
            itemRef.coin -= valueFinal;
            itemRef.woodAmount += valueFinal;
            shoopUi.SetActive(false);
        }
        else if(buyingStone&&itemRef.coin!=0)
        {
            itemRef.coin -= valueFinal;
            itemRef.stoneAmount += valueFinal;
            shoopUi.SetActive(false);
        }

        else if (buyingSand && itemRef.coin != 0)
        {
            itemRef.coin -= valueFinal;
            itemRef.sandAmount += valueFinal/2;
            shoopUi.SetActive(false);
        }
        else if (buying3 && itemRef.coin != 0)
        {
            itemRef.coin -= valueFinal/2;
            itemRef.sandstoneAmount += valueFinal;
            shoopUi.SetActive(false);
        }
        else if (buying4 && itemRef.coin != 0)
        {
            itemRef.coin -= valueFinal*3;
            itemRef.clayAmount += valueFinal;
            shoopUi.SetActive(false);
        }
        else if (buying5 && itemRef.coin != 0)
        {
            itemRef.coin -= valueFinal*3;
            itemRef.brickAmount += valueFinal;
            shoopUi.SetActive(false);
        }
        else if (buying6 && itemRef.coin != 0)
        {
            itemRef.coin -= valueFinal*5;
            itemRef.coalAmount += valueFinal;
            shoopUi.SetActive(false);
        }
        else if (buying7 && itemRef.coin != 0)
        {
            itemRef.coin -= valueFinal*5;
            itemRef.ironAmount += valueFinal;
            shoopUi.SetActive(false);
        }

    }
}

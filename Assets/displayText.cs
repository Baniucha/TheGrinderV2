using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class displayText : MonoBehaviour
{
    public Text woodAmount, stoneAmount, sandAmount, lvl2Good, lvl3Good, lvl3Good2, lvl4Good,lvl4Good2, lvl5Good, lvl5Good2;
    public Item itemRef;
    public TextMeshProUGUI text, coinText, coinTextUI, sellingOrBuying, goodsValue;
    public Text btnText1, btnText2;
    public string doYouWannaBuildIt = "Do you want to build it?";
    public string yes = "Yes";
    public string no = "No";
    public string upgradeYourBase = "Upgrade your base";
    public ShopScript shop;
    public Slider sliderRef;
    public ShopSlider shopSliderRef;
    // Start is called before the first frame update
    void Start()
    {
        btnText1.text = "Yes";
        btnText2.text = "No";
        text.text = "Do you want to build it?";
    }

    // Update is called once per frame
    void Update()
    {
        if(shop.isBuying)
        {
            sellingOrBuying.text = "You are now buying";
        }
        else if (shop.isSelling)
        {
            sellingOrBuying.text = "You are now selling";
        }
        coinText.text  = coinTextUI.text = itemRef.coin.ToString();
        
        goodsValue.text = sliderRef.value.ToString();
        woodAmount.text = "Wood: " + itemRef.woodAmount.ToString();
        stoneAmount.text = "Stone: " + itemRef.stoneAmount.ToString();
        sandAmount.text = "Sand: " + itemRef.sandAmount.ToString();
        lvl2Good.text = "Sandstone: " + itemRef.sandstoneAmount.ToString();
        lvl3Good.text = "Clay: " + itemRef.clayAmount.ToString();
        lvl3Good2.text = "Brick: " + itemRef.brickAmount.ToString();
        lvl4Good.text = "Iron: " + itemRef.ironAmount.ToString();
        lvl4Good2.text = "Coal: " + itemRef.coalAmount.ToString();
        lvl5Good.text = "Silver: " + itemRef.silverAmount.ToString();
        lvl5Good2.text = "Diamond: " + itemRef.diamondAmount.ToString();

        if(shopSliderRef.sellindStone)
        {
            sellingOrBuying.text = " You are selling stone now";
        }
        if (shopSliderRef.selling1)
        {
            sellingOrBuying.text = " You are selling sandstone now";
        }
        if (shopSliderRef.selling2)
        {
            sellingOrBuying.text = " You are selling clay now";
        }
        if (shopSliderRef.selling3)
        {
            sellingOrBuying.text = " You are selling brick now";
        }
        if (shopSliderRef.selling4)
        {
            sellingOrBuying.text = " You are selling iron now";
        }
        if (shopSliderRef.selling5)
        {
            sellingOrBuying.text = " You are selling coal now";
        }
        if (shopSliderRef.selling6)
        {
            sellingOrBuying.text = " You are selling silver now";
        }
        if (shopSliderRef.selling7)
        {
            sellingOrBuying.text = " You are selling diamond now";
        }
        if (shopSliderRef.sellingSand)
        {
            sellingOrBuying.text = " You are selling sand now";
        }
        if (shopSliderRef.sellingWood)
        {
            sellingOrBuying.text = " You are selling wood now";
        }



        if (shopSliderRef.buyingStone)
        {
            sellingOrBuying.text = " You are buying stone now";
        }
        if (shopSliderRef.buyingWood)
        {
            sellingOrBuying.text = " You are buying wood now";
        }
        if (shopSliderRef.buyingSand)
        {
            sellingOrBuying.text = " You are buying sand now";
        }
        if (shopSliderRef.buying3)
        {
            sellingOrBuying.text = " You are buying sandstone now";
        }
        if (shopSliderRef.buying4)
        {
            sellingOrBuying.text = " You are buying clay now";
        }
        if (shopSliderRef.buying5)
        {
            sellingOrBuying.text = " You are buying brick now";
        }
        if (shopSliderRef.buying6)
        {
            sellingOrBuying.text = " You are buying coal now";
        }

        if (shopSliderRef.buying7)
        {
            sellingOrBuying.text = " You are buying iron now";
        }

    }
}

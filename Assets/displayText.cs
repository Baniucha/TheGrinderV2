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
        lvl2Good.text = "Good1: " + itemRef.lvl2Good2.ToString();
        lvl3Good.text = "Good1: " + itemRef.lvl3Good1.ToString();
        lvl3Good2.text = "Good1: " + itemRef.lvl3Good2.ToString();
        lvl4Good.text = "Good1: " + itemRef.lvl4Good1.ToString();
        lvl4Good2.text = "Good1: " + itemRef.lvl4Good2.ToString();
        lvl5Good.text = "Good1: " + itemRef.lvl5Good1.ToString();
        lvl5Good2.text = "Good1: " + itemRef.lvl5Good2.ToString();

        if(shopSliderRef.sellindStone)
        {
            sellingOrBuying.text = " You are selling stone now";
        }
        if (shopSliderRef.selling1)
        {
            sellingOrBuying.text = " You are selling 1 now";
        }
        if (shopSliderRef.selling2)
        {
            sellingOrBuying.text = " You are selling 2 now";
        }
        if (shopSliderRef.selling3)
        {
            sellingOrBuying.text = " You are selling 3 now";
        }
        if (shopSliderRef.selling4)
        {
            sellingOrBuying.text = " You are selling 4 now";
        }
        if (shopSliderRef.selling5)
        {
            sellingOrBuying.text = " You are selling 5 now";
        }
        if (shopSliderRef.selling6)
        {
            sellingOrBuying.text = " You are selling 6 now";
        }
        if (shopSliderRef.selling7)
        {
            sellingOrBuying.text = " You are selling 7 now";
        }
        if (shopSliderRef.sellingSand)
        {
            sellingOrBuying.text = " You are selling sand now";
        }
        if (shopSliderRef.sellingWood)
        {
            sellingOrBuying.text = " You are selling wood now";
        }
    }
}

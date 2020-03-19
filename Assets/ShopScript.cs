using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopScript : MonoBehaviour
{



    public GameObject shopUI, goodsUI,wouldYouLikeTo;
    public bool isSelling;
    public bool isBuying;
    Vector3 hideVector;
    Vector3 showVector;
    public Slider slider;
    public ShopSlider tradeRef;
    private void Start()
    {
        hideVector = new Vector3(0, 0, 0);
        showVector = new Vector3(1, 1, 1);
        isSelling = false;
        isBuying = false;
        shopUI.SetActive(false);
        goodsUI.gameObject.SetActive(false);
        slider.gameObject.SetActive(false);
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopUI.SetActive(true);
            wouldYouLikeTo.transform.localScale = showVector;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopUI.SetActive(false);
            goodsUI.gameObject.SetActive(false);
            isSelling = false;
            isBuying = false;

            tradeRef.buying1 = tradeRef.buying2 = tradeRef.buying3 = tradeRef.buying4 = tradeRef.buying5 = tradeRef.buying6 = tradeRef.buying7 = tradeRef.buyingSand = tradeRef.buyingStone = tradeRef.buyingWood = tradeRef.sellindStone = tradeRef.selling1 = tradeRef.selling2 = tradeRef.selling3 = tradeRef.selling4 = tradeRef.selling5 = tradeRef.selling6 = tradeRef.selling7 = tradeRef.sellingSand = tradeRef.sellingWood = false;
            slider.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
     
    }
    public void Buy()
    {
        isBuying = true;
        isSelling = false;
        goodsUI.gameObject.SetActive(true);
        wouldYouLikeTo.transform.localScale = hideVector;
    }

    public void Sell()
    {
        isSelling = true;
        isBuying = false;
        goodsUI.gameObject.SetActive(true);
        wouldYouLikeTo.transform.localScale = hideVector;
    }
    public void Test()
    {
        if(isSelling)
        {
            //sell
            slider.gameObject.SetActive(true);
        }
        else if (isBuying)
        {
            slider.gameObject.SetActive(true);
            //buy
        }
    }
}

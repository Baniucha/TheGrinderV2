using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//SCRIPT RESPONSBILE FOR AIR BAR
public class AirBar : MonoBehaviour
{
    //variables
    Image airbar;
    public Image airbarBackground;
    public Player playerair;

    // Start is called before the first frame update
    void Start()
    {
        //get image component
        //set air value to max air value
        //disable background and airbar on start
        airbar = GetComponent<Image>();
        playerair.air= playerair.maxAir;
        airbarBackground.enabled = false;
        airbar.enabled = false ;
    }

    // Update is called once per frame
    void Update()
    {
        //if player is swimming
        //enable background and airbar
        //display value as a bar

        //if player is not swimming
        //disable background and airbar
        if(playerair.swim)
        {
            airbarBackground.enabled = true;
            airbar.enabled = true;
            airbar.fillAmount = playerair.air / playerair.maxAir;
        }
        else
        {
            airbarBackground.enabled = false;
            airbar.enabled = false;
        }
    }
}

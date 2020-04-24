using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirBar : MonoBehaviour
{
    Image airbar;
    public Image airbarBackground;
    public Player playerair;

    // Start is called before the first frame update
    void Start()
    {
        airbar = GetComponent<Image>();
        playerair.air= playerair.maxAir;
        airbarBackground.enabled = false;
        airbar.enabled = false ;
    }

    // Update is called once per frame
    void Update()
    {
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

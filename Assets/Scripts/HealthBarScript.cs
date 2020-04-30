using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//SCRIPT RESPONSIBLE FOR HEALTHBAR
public class HealthBarScript : MonoBehaviour
{
    //VARIABLES
    Image healthBar;

    public Player playerhp;
    
    // Start is called before the first frame update
    void Start()
    {
        //SET VARIABLES
        healthBar = GetComponent<Image>();
        playerhp.actualHealth= playerhp.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //CALCULATE AND DISPLAY HEALTH BAR
        healthBar.fillAmount = playerhp.actualHealth / playerhp.maxHealth;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarScript : MonoBehaviour
{
    Image healthBar;
    public Player playerhp;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        playerhp.actualHealth= playerhp.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = playerhp.actualHealth / playerhp.maxHealth;
    }
}

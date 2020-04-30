using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT RESPONSIBLE FOR DISPLAYING HEALTH BAR OF ENEMY
public class EnemyHealthBar : MonoBehaviour
{

    //VARIABLES
    Vector3 localScale;
    public Enemy enemyHealthRef;
    // Start is called before the first frame update
    void Start()
    {
        //SET VARIABLE
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //DISPLAY CORRECTLY ENEMY HEALTH
        localScale.x = enemyHealthRef.health/50;
        transform.localScale = localScale;
    }
}

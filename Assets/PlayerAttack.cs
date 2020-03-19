using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAtack;
    public float startTimeBetweenAttack;
   
    public Transform attackPos;
    public LayerMask enemyMask;
    public float attackRange;
    public int dmg;
    public GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
        sword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenAtack <= 0)
        {

            if (Input.GetKey(KeyCode.F)|| Input.GetKeyDown(KeyCode.F))
            {
                sword.SetActive(true);
                AttackEnemy();
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {
                sword.SetActive(false);
            }
            //Atack
            timeBetweenAtack = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenAtack -= Time.deltaTime;
            sword.SetActive(false);
        }
        

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    void AttackEnemy()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyMask);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(dmg);
        }
    }
}

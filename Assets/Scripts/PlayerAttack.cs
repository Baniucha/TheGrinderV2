using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT RESPONSIBLE FOR PLAYER ATTACK
public class PlayerAttack : MonoBehaviour
{

    //VARIABLES
    public float timeBetweenAtack;
    public float startTimeBetweenAttack;
   
    public Transform attackPos;
    public LayerMask enemyMask;
    public LayerMask treeMask;
    public LayerMask stoneMask;
    public LayerMask sandMask;
    public LayerMask clayMask;
    public LayerMask coalMask;
    public LayerMask enemyCoalMask;
    public float attackRange;
    public int dmg;
    public int dmgToObj;
    public GameObject sword,shield;
    public bool imShielding;
    public ToolShop tool;
    public Audio audio;
    // Start is called before the first frame update
    void Start()
    {
        //SET VARIABLES
        dmg = 2;
        sword.SetActive(false);
        shield.SetActive(false);
        imShielding = false;
    }

    // Update is called once per frame
    void Update()
    {
        //COOLDOWN FOR ATTACKING IN ORDER TO PREVENT FROM CONSTANT ATTACKING
        //PERFORM THIS IF STATEMENT IF PLAYER IS NOT SHIELDING
        if (timeBetweenAtack <= 0&&!imShielding)
        {
            //PRESS F TO ATTACK
            //CALL FUNCTIONS
            if (Input.GetKey(KeyCode.F)|| Input.GetKeyDown(KeyCode.F))
            {
                sword.SetActive(true);
                AttackEnemy();
                AttackTree();
                AttackStone();
                AttackSand();
                AttackClay();
                AttackCoal();
                AttackEnemyCoal();
            }
            //PLAYER STOPS ATTACKING
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
        //PLAYER IS SHIELDING
        if(Input.GetMouseButton(1))
        {
            shield.SetActive(true);
            imShielding = true;
        }
        else
        {
            shield.SetActive(false);
            imShielding = false;
        }

    }
    //DETECTING COLLIDERS
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    //FUNCTIONS RESPONSIBLE FOR ATTACKING ENEMIES AND OBJECTS THAT ALLOW PLAYER TO GATHER GOODS
    void AttackEnemy()
    {
        
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyMask);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(dmg);
        }
    }
    void AttackEnemyCoal()
    {

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyCoalMask);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(dmg);
        }
    }
    void AttackTree()
    {
        Collider2D[] treesToDmg = Physics2D.OverlapCircleAll(attackPos.position, attackRange, treeMask);
       
            for (int i = 0; i < treesToDmg.Length; i++)
            {
            if (tool.iHaveAxe)
            {
                audio.chopTree.Play();
                treesToDmg[i].GetComponent<Tree>().TakeDmg(dmgToObj);
            }  
            }
    }
    void AttackStone()
    {
        Collider2D[] stonesToDmg = Physics2D.OverlapCircleAll(attackPos.position, attackRange, stoneMask);
        for (int i = 0; i < stonesToDmg.Length; i++)
        {
            if (tool.iHavePickaxe)
            {
                audio.pickaxe.Play();
                stonesToDmg[i].GetComponent<BigStone>().TakeDmg(dmgToObj);
            }
        }
    }
    void AttackSand()
    {
        Collider2D[] sandsToDmg = Physics2D.OverlapCircleAll(attackPos.position, attackRange, sandMask);
        for (int i = 0; i < sandsToDmg.Length; i++)
        {
            if (tool.iHaveShovel)
            {
                audio.shovel.Play();
                sandsToDmg[i].GetComponent<BigSand>().TakeDmg(dmgToObj);
            }
        }
    }
    void AttackClay()
    {
        Collider2D[] clayToDmg = Physics2D.OverlapCircleAll(attackPos.position, attackRange, clayMask);
        for (int i = 0; i < clayToDmg.Length; i++)
        {
            if (tool.iHaveShovel)
            {
                audio.shovel.Play();
                clayToDmg[i].GetComponent<BigClay>().TakeDmg(dmgToObj);
            }
        }
    }
    void AttackCoal()
    {
        Collider2D[] clayToDmg = Physics2D.OverlapCircleAll(attackPos.position, attackRange, coalMask);
        for (int i = 0; i < clayToDmg.Length; i++)
        {
            if (tool.iHavePickaxe)
            {
                clayToDmg[i].GetComponent<BigCoal>().TakeDmg(dmgToObj);
                audio.shovel.Play();
            }
        }
    }
}

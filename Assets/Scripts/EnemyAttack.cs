using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//SCRIPT RESPONSIBLE FOR ENEMY ATTACK
public class EnemyAttack : MonoBehaviour
{

    //VARIABLES
    Transform target;
    public float lookRadiusAttack = 1f;
    public Transform attackPos;
    public float timeBetweenAttack;
    public float startTimeBetweenAttack;
    public LayerMask playerMask;
    public float attackRange;
    public int dmg;
    public GameObject sword1, sword2, sword3,player;
    public PlayerAttack playerRef;
    // Start is called before the first frame update
    void Start()
    {

        //SET VARIABLES ON START
        player = GameObject.FindGameObjectWithTag("Player");
        playerRef = player.GetComponent<PlayerAttack>();
        sword1.SetActive(false);
        sword2.SetActive(false);
        sword3.SetActive(false);
        dmg = 5;
        target = PlayerManager.instance.player.transform;

    }

    // Update is called once per frame
    void Update()
    {
        //ENEMY MOVES TO PLAYER AND IF CLOSE ENOUGH ATTACKS
        //SWORD OBJECTS REPRESENT SWORDS
        float distance = Vector3.Distance(target.position, transform.position);

        if (timeBetweenAttack <= 0&&!playerRef.imShielding)
        {
            if (distance <= lookRadiusAttack)
            {
                sword1.SetActive(true);
                sword2.SetActive(true);
                sword3.SetActive(true);
                Attack();
            }
            timeBetweenAttack = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
            sword1.SetActive(false);
            sword2.SetActive(false);
            sword3.SetActive(false);
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadiusAttack);
    }

    //ATTACK FUNCTION
    //IT TAKES PLAYER'S HP AND IT SUBTRACTS DMG FROM HP
    void Attack()
    {
        Collider2D[] playerToDMG = Physics2D.OverlapCircleAll(attackPos.position, attackRange, playerMask);
        for (int i = 0; i < playerToDMG.Length; i++)
        {
            playerToDMG[i].GetComponent<invulnerability>().PlayerTakesDmg(dmg);
        }
    }
}


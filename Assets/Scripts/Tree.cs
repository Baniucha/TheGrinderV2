using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT RESPONSIBLE FOR TREES
public class Tree : MonoBehaviour
{
    //VARIABLES
    public float treeHp;
    public PlayerAttack playerDmg;
    Vector3 scaleChange, posChange,vectorZero;
    public float countDown = 5f;
    public bool hasGrown;
  public  float cd;
    public float finalCd;
    Vector3 startPos;
    public GameObject wood;
    Transform thisTransform;
    bool spawned;
    private void Awake()
    {
        //SET VARIABLES
        thisTransform = GetComponent<Transform>();
        startPos = this.transform.position;
        StartCoroutine("Grow");
    }
    private void Start()
    {
        //SET VARIABLES
        hasGrown = true;
        treeHp = 5;
        scaleChange = new Vector3(0.005f, 0.015f, 0.001f);
        posChange = new Vector3(0, 0.005f, 0);
    }
    private void Update()
    {
        //IF HP IS LESS OR EQUAL 0
        //STOP GROW COROUTINE
        //CHANGE SCALE (IN ORDER TO IMPROVE PERFORMANCE SCALE IS CHANGED TO 0 INSTEAD OF DESTROYED)
        //STAR COROUTINE WAIT
        if(treeHp<=0)
        {
            StopCoroutine("Grow");
            this.transform.localScale = new Vector3(0, 0, 0);
            if(!spawned)
            {
                spawned = true;
                Instantiate(wood, thisTransform.position, Quaternion.identity);
            }
            StartCoroutine("Wait");
        }
    }
  
    //FUNCTION RESPONSIBLE FOR TAKING DMG
    public void TakeDmg(int dmg)
    {      
            treeHp -= dmg;
    }
    //AFTER HP IS SET TO 0
    //WAIT FROM 20 TO 60 SECONDS
    //TREE GROWS FOR .25 SECOND

   IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(20,60));
        countDown = .25f;
        spawned = false;
        StartCoroutine("Grow");
    }

    //COROUTINE THAT CHANGES LOCAL SCALE OF A TREE
    //SIMULATES GROWTH OF THE TREE
    //SET HP TO 9999 IN ORDER SO PLAYER CANNOT DESTROY IT WHILE IT IS GROWING
    //WHEN COUNTDOWN IS LESS THAN 0 SET HP OF THE TREE TO 5 HP
    IEnumerator Grow()
    {
        StopCoroutine("Wait");
        this.transform.position = startPos;
        this.transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
        for (int i = 0; i < 1000; i++)
            {
                while (countDown >= 0)
                {
                treeHp = 9999;
                    this.transform.localScale += scaleChange;
                    this.transform.position += posChange;
                    countDown -= Time.smoothDeltaTime;
                    yield return null;
                }
                if (countDown <= 0)
                {
                    treeHp = 5;
 
                }
            }
        
    }
    
}

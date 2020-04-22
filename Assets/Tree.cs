using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
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
        thisTransform = GetComponent<Transform>();
        startPos = this.transform.position;
        StartCoroutine("Grow");
    }
    private void Start()
    {
        hasGrown = true;
        treeHp = 5;
        scaleChange = new Vector3(0.005f, 0.015f, 0.001f);
        posChange = new Vector3(0, 0.005f, 0);
    }
    private void Update()
    {
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
  
    public void TakeDmg(int dmg)
    {      
            treeHp -= dmg;
    }
   IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(20,60));
        countDown = 5;
        spawned = false;
        StartCoroutine("Grow");
    }
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

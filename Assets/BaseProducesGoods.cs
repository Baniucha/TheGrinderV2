using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProducesGoods : MonoBehaviour
{
    public baseScript baseRef;
    public int wood,stone,sand,sandStone,clay,brick,coal,iron;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (baseRef.woodUpgraded || baseRef.stoneUpgraded || baseRef.sandUpgraded || baseRef.good2Upgraded)
        {
            StartCoroutine("ProduceGoods");
        }
      
    }
    IEnumerator ProduceGoods()
    {
        yield return new WaitForSeconds(1);

        if (baseRef.woodUpgraded)
        {
            wood ++;
        }
        else if (baseRef.stoneUpgraded)
        {
            stone++;
        }


         if(baseRef.sandUpgraded)
        {
            sand++;
        }
        else if (baseRef.good2Upgraded)
        {
            sandStone++;
        }


         if(baseRef.lvl3Good1Upgraded)
        {
            clay++;
        }
         else if(baseRef.lvl3Good2Upgraded)
        {
            brick++;
        }

         if(baseRef.lvl4Good1Upgraded)
        {
            iron++;
        }
         else if(baseRef.lvl4Good2Upgraded)
        {
            coal++;
        }

      

        StopCoroutine("ProduceGoods");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            baseRef.itemRef.woodAmount += wood;
            baseRef.itemRef.stoneAmount += stone;
            baseRef.itemRef.sandAmount += sand;
            baseRef.itemRef.sandstoneAmount += sandStone;
            baseRef.itemRef.clayAmount += clay;
            baseRef.itemRef.brickAmount += brick;
            baseRef.itemRef.coalAmount += coal;
            baseRef.itemRef.ironAmount += iron;


            wood = stone=sand=sandStone=clay=brick=coal=iron= 0;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProducesGoods : MonoBehaviour
{
    public baseScript baseRef;
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
            baseRef.itemRef.woodAmount++;
        }
        else if (baseRef.stoneUpgraded)
        {
            baseRef.itemRef.stoneAmount++;
        }


         if(baseRef.sandUpgraded)
        {
            baseRef.itemRef.sandAmount++;
        }
        else if (baseRef.good2Upgraded)
        {
            baseRef.itemRef.lvl2Good2++;
        }


         if(baseRef.lvl3Good1Upgraded)
        {
            baseRef.itemRef.lvl3Good1++;
        }
         else if(baseRef.lvl3Good2Upgraded)
        {
            baseRef.itemRef.lvl3Good2++;
        }

         if(baseRef.lvl4Good1Upgraded)
        {
            baseRef.itemRef.lvl4Good1++;
        }
         else if(baseRef.lvl4Good2Upgraded)
        {
            baseRef.itemRef.lvl4Good2++;
        }

      

        StopCoroutine("ProduceGoods");
    }
}

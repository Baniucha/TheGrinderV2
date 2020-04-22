using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject[] cubes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject cube in cubes)
        {
            if(cube.activeInHierarchy)
            {
                for (int i = 0; i < cubes.Length; i++)
                {
                    cubes[i].transform.localScale += new Vector3(.0001f, .0001f, .0001f);
                }
            }
            else if (!cube.activeInHierarchy)
            {
                for (int i = 0; i < cubes.Length; i++)
                {
                    cube.transform.localScale -= new Vector3(1, .0001f, .0001f);
                }
            }
        }
    }
}

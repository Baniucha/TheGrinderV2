using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT RESPONSIBLE FOR POSITIONS OF FALLING ROCKS
public class ManagerFallingRocks : MonoBehaviour
{

    //VARIABLES
    public Transform[] dropPos;
    Player player;
    int r;
    public GameObject rock;
    float dropRate;
    float nextDrop;
    // Start is called before the first frame update
    void Start()
    {
        //FIND PLAYER AND SET VARIABLES
        player = GameObject.Find("Player").GetComponent<Player>();
        dropRate = Random.Range(2, 5) ;
        nextDrop = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
       
        //IF PLAYER IS ON COAL GROUND
        //SET TIME BACK TO ORIGINAL
        //CALL DROPROCK FUNCTION 
        if (player.onCoalPos)
        {
            if (Time.time > nextDrop)
            {
                r = Random.Range(0, 3);
                nextDrop = Time.time + dropRate;
                DropRock();
            }
        }
    }
    void DropRock()
    {
        //DEPENDING ON RNG
        //INSTANTIATE ROCKS ON DIFFERENT POSITIONS
        if(r==0)
        {
            Instantiate(rock, dropPos[0].position, Quaternion.identity);
            Instantiate(rock, dropPos[1].position, Quaternion.identity);
        }
        if (r == 1)
        {
            Instantiate(rock, dropPos[2].position, Quaternion.identity);
            Instantiate(rock, dropPos[3].position, Quaternion.identity);
        }
        if (r == 2)
        {
            Instantiate(rock, dropPos[4].position, Quaternion.identity);
            Instantiate(rock, dropPos[5].position, Quaternion.identity);
        }
    }
   
}

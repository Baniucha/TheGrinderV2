using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Item")]
public class Item : ScriptableObject
{
    public new string name;

    //gold amount
    public int coin;


    //lvl1 goods
    public int woodAmount;
    public int stoneAmount;

    //lvl2 goods
    public int sandAmount;
    public int lvl2Good2;

    //lvl3 goods
    public int lvl3Good1;
    public int lvl3Good2;

    //lvl4 goods
    public int lvl4Good1;
    public int lvl4Good2;

    //lvl5 goods
    public int lvl5Good1;
    public int lvl5Good2;
}

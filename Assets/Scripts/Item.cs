using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT RESPONSIBLE FOR GOODS
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
    public int sandstoneAmount;

    //lvl3 goods
    public int clayAmount;
    public int brickAmount;

    //lvl4 goods
    public int ironAmount;
    public int coalAmount;

    //lvl5 goods
    public int silverAmount;
    public int diamondAmount;
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//SCRIPT RESPONSIBLE FOR AUDIO
public class Audio : MonoBehaviour
{

    //variables
    public AudioSource chopTree;
    public AudioSource pickaxe;
    public AudioSource shovel;
    public AudioSource pickUp;
    public AudioSource cannon;
    public AudioSource gunShot;
    public AudioSource rock;
    // Start is called before the first frame update
    void Start()
    {
        //set different sound to arrays 
        var sources = GetComponents<AudioSource>();
        chopTree = sources[0];
        pickaxe = sources[1];
        shovel = sources [2];
        pickUp = sources[3];
        cannon = sources[4];
        gunShot = sources[5];
        rock = sources[6];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

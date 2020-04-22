using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource chopTree;
    public AudioSource pickaxe;
    public AudioSource shovel;
    public AudioSource pickUp;
    public AudioSource cannon;
    // Start is called before the first frame update
    void Start()
    {
        var sources = GetComponents<AudioSource>();
        chopTree = sources[0];
        pickaxe = sources[1];
        shovel = sources [2];
        pickUp = sources[3];
        cannon = sources[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

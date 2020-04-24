using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Player posRef;
    public Transform pos1, pos2,pos3,pos22,posSand,posClay;
    public float step = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(posRef.onPos1)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, pos1.transform.position, step * Time.deltaTime);
        }
        else if (posRef.onPos2)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, pos2.transform.position, step * Time.deltaTime);
        }
        else if (posRef.onPos3)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, pos3.transform.position, step * Time.deltaTime);
        }
        else if (posRef.onPos22)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, pos22.transform.position, step * Time.deltaTime);
        }
        else if(posRef.onSandPos)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, posSand.transform.position, step * Time.deltaTime);
        }
        else if (posRef.onClayPos)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, posClay.transform.position, step * Time.deltaTime);
        }
    }
  
}

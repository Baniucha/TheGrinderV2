using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing1 : MonoBehaviour
{
    float desiredRot;
    public float rotSpeed = 250;
    public float damping = 10;
    private void OnEnable()
    {
        desiredRot = transform.eulerAngles.x;
    }
    // Update is called once per frame
    void Update()
    {
        if (desiredRot < 30)
        {
            desiredRot -= rotSpeed * Time.deltaTime;
        }
        else if(desiredRot<-30)
        {
          //  desiredRot += rotSpeed * Time.deltaTime;
        }
        var desiredRotQ = Quaternion.Euler(desiredRot, transform.eulerAngles.y, transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }
}

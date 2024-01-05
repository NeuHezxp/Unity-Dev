using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rate;
    public float speed;


    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(rate * Time.deltaTime, transform.up) ;
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
}

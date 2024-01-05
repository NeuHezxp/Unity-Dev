using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float force;
    public float gravity;

    Rigidbody rb;
    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {

            rb.AddForce(transform.up * force, ForceMode.VelocityChange);
        }
    }
}

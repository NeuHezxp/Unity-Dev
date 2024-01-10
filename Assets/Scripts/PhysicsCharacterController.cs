using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PhysicsCharacterController : MonoBehaviour
{

    Rigidbody rb;
    public Vector3 force = Vector3.zero;
    public float maxForce = 5;
    public float jumpForce = 5;
    Transform view;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.y = Input.GetAxis("Vertical");
        direction.x = Input.GetAxis("Horizontal");

        force = view.rotation * direction * maxForce;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(force, ForceMode.Force);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PhysicsCharacterController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform view;
    public Vector3 force = Vector3.zero;
    public float maxForce = 5;
    public float jumpForce = 5;
   // Transform view;
    [Header("Collision")]
    Rigidbody rb;
    public float rayLength = 1;
    public LayerMask groundLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // cursor dissapears when clicking on the screen
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.y = Input.GetAxis("Vertical");
        direction.x = Input.GetAxis("Horizontal");

        Quaternion yrotation = Quaternion.AngleAxis(view.rotation.eulerAngles.y,Vector3.up);
        force = yrotation * direction * maxForce;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(force, ForceMode.Force);
    }
    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position,Vector3.down * rayLength, Color.red,1);
        return Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayerMask);
    }
}

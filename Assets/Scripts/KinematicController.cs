using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour
{

    [SerializeField, Range(0, 40)] float speed = 1;
    [SerializeField] float maxDistance = 5;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        float distance = transform.localPosition.magnitude;
        if (distance > maxDistance)
        {

        }

        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        Vector3 force = direction * speed * Time.deltaTime;
        transform.localPosition += force; // equivlent to transoform.position += force

        transform.localPosition = Vector3.ClampMagnitude(transform.localPosition, maxDistance);

    }
}

using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{

    [SerializeField] Transform target = null;
    [SerializeField][UnityEngine.Range(20, 90)] float pitch = 40;
    [SerializeField] float distance = 5;
    [SerializeField]
    [UnityEngine.Range(0.1f, 2)] float sensitivity = 0.2f;
    float yaw = 0;
    
    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        Quaternion qYaw = Quaternion.AngleAxis(yaw, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);
        Quaternion rotation = qYaw * qpitch;

        transform.position = target.position + (qpitch *Vector3.back * distance);
        transform.rotation = rotation;
    }
}

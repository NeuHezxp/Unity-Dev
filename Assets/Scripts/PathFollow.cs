using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class PathFollow : MonoBehaviour
{
    [SerializeField] SplineContainer splineContainer;
    [Range(0,40)] public float speed = 1;

    float tDistance = 0; //distance along spline  (0-1)

    //public float speed { get; set; }
    //length in world coordinates
    public float length { get { return splineContainer.CalculateLength(); } }
    //distance in world
    public float distance
    {
        get { return tDistance * length; }
        set { tDistance = value / length; }
    }

    
    void Update()
    {
        distance += speed * Time.deltaTime;
        UpdateTransform(math.frac(tDistance));
    }

    void UpdateTransform(float t)
    {
        Vector3 position = splineContainer.EvaluatePosition(t);
        Vector3 up = splineContainer.EvaluateUpVector(t);
        Vector3 forward = Vector3.Normalize(splineContainer.EvaluateTangent(t));
        Vector3 right = Vector3.Cross(up, forward);

        transform.position = position;
        transform.rotation = quaternion.LookRotation(forward, up);
    }
}

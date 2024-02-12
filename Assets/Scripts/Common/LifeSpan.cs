using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    [SerializeField, Range(0, 30)] float lifespan = 1;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifespan);
    }
}
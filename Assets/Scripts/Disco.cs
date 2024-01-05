using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disco : MonoBehaviour
{
    public Light light = null;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        //make the color of the light random
        light.color = Random.ColorHSV();
    }
}

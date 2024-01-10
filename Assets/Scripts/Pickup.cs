using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pickupPrefab = null;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name + " collided with " + gameObject.name);
    }
    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name + " collided with " + gameObject.name);
        Instantiate(pickupPrefab, transform.position, Quaternion.identity); //quaternion.identity is for no rotation
        Destroy(gameObject);
    }
}

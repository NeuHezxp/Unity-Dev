using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            inventory.Use();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            inventory.stopUse();
        }

        if (Input.GetKeyDown(KeyCode.Tab)) inventory.nextItem();
        if (Input.GetKeyDown(KeyCode.LeftShift)) inventory.previousItem();
    }
}

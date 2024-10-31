using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThneedSeed : MonoBehaviour
{
    // Optional: Rotate the seed to give it a floating effect
    public float rotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the seed around the Z-axis to give a visual effect
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    // This method is called when another collider enters the trigger area
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding with the seed is the Lorax (tagged as "Lorax")
        if (other.CompareTag("Lorax"))
        {
            // Destroy the seed game object
            Destroy(gameObject);
            Debug.Log("Seed collected");
        }
    }

    internal bool isCollectedBy(GameObject lorax)
    {
        throw new NotImplementedException();
    }
}

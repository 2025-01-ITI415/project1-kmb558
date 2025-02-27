using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public float speed = 5f;  // Speed of movement
    public float xDestroyThreshold = 10f; // X position where apple disappears

    void Update()
    {
        // Move the apple along the x-axis instead of y
        transform.position += Vector3.right * speed * Time.deltaTime;

        // Check if the apple has moved past the threshold on the x-axis
        if (Mathf.Abs(transform.position.x) > xDestroyThreshold)
        {
            Destroy(gameObject);
        }
    }
}
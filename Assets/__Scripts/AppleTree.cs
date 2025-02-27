using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Prefab for instantiating apples + unique types
    public GameObject applePrefab;


    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance at which the AppleTree moves
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    // Rate at which Apple will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    { // Dropping apples every second
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {

        Invoke("DropApple", secondsBetweenAppleDrops);

        AppleType();

    }

    void AppleType()
    {

        float randomValue = Random.value;


        {
            GameObject apple = Instantiate(applePrefab);
            applePrefab.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement

        Vector3 pos = transform.position;

        pos.z += speed * Time.deltaTime; // Due to my camera's orientation, I changed to z direction

        transform.position = pos;

        // Changing Direction
        if (pos.z < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.z > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }
    }
    void FixedUpdate()
    {
        // Changing Direction Randomly is now t

        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; // Change direction
        }
    }
}
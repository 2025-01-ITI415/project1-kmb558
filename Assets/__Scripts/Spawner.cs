using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Prefab for instantiating apples + unique types
    public GameObject attackerPrefab;
    public GameObject GameOverScreenPrefab;

    // Speed at which the Spawner moves
    public float speed = 1f;

    // Distance at which the Spawner moves
    public float leftAndRightEdge = 10f;

    // Chance that the Spawner will change directions
    public float chanceToChangeDirections = 0.1f;

    // Rate at which attackers will be instantiated
    public float secondsBetweenAttackerSpawn = 1f;
    public float chanceforAttacker = 0.5f;

    // Start is called before the first frame update
    void Start()
    { // Dropping apples every second
        Invoke("SpawnAttacker", 2f);
    }

    void SpawnAttacker()
    {

        Invoke("SpawnAttacker", secondsBetweenAttackerSpawn);

        AttackerType();

    }

    void AttackerType()
    {

        float randomValue = Random.value;

    
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

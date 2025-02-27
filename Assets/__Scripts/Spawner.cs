using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject attackerPrefab; // Prefab for instantiating attackers

    public float speed = 1f; // Speed at which the Spawner moves
    public float leftAndRightEdge = 10f; // Movement boundary
    public float chanceToChangeDirections = 0.1f; // Chance to change direction
    public float secondsBetweenSpawns = 1f; // Spawn rate

    void Start()
    {
        // Start spawning attackers every few seconds
        InvokeRepeating("SpawnAttacker", 2f, secondsBetweenSpawns);
    }

    void SpawnAttacker()
    {
        // Instantiate attacker at the spawner's position
        GameObject newAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        // Move spawner left and right along the z-axis
        Vector3 pos = transform.position;
        pos.z += speed * Time.deltaTime;
        transform.position = pos;

        // Reverse direction when hitting movement boundaries
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
        // Random chance to change direction
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}

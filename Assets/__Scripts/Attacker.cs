using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene reloading

public class Attacker : MonoBehaviour
{
    public float speed = 5f;  // Speed of movement
    public float destroyDistance = 40f; // Distance to destroy after moving
    public float pushBackForce = 10f;  // Force applied on collision
    public float pushUpForce = 5f; // Vertical force to make it "fly"
    private Vector3 spawnPosition;
    private Rigidbody rb; // Rigidbody 

    void Start()
    {
        spawnPosition = transform.position;
        rb = GetComponent<Rigidbody>();

        // If no Rigidbody, add one
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        rb.isKinematic = false; // Allow physics-based movement
        rb.useGravity = true; // Optional: enable gravity if needed
    }

    void Update()
    {
        // Move attacker along the x-axis
        transform.position += Vector3.right * speed * Time.deltaTime;

        // Destroy after traveling set distance
        if (Vector3.Distance(spawnPosition, transform.position) >= destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    // Apply force when colliding with the player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Ensure the player has this tag
        {
            Vector3 pushDirection = (transform.position - collision.transform.position).normalized;
            pushDirection.y = 0; // Keep force horizontal
            rb.AddForce(pushDirection * pushBackForce + Vector3.up * pushUpForce, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("GameOverTrigger")) // Tag must match
        {
            GameOver();
        }

        void GameOver()
        {
            Debug.Log("Game Over!");
            // Example: Restart the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // OR: Show a UI Game Over screen instead

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncelerFollowLorax : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public int damage = 1;
    private PlayerHealth playerHealth;
    private Vector3 startingPosition;
    private bool isFacingRight = true; // Track the Onceler’s facing direction
    public Vector2 randomSpawnRangeX = new Vector2(-10f, 10f); // X-axis range for random spawn
    public Vector2 randomSpawnRangeY = new Vector2(-5f, 5f);   // Y-axis range for random spawn

    private Level3SceneManager sceneManager; // Reference to Level3SceneManager

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Lorax");

        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }

        // Get the Level3SceneManager instance
        sceneManager = FindObjectOfType<Level3SceneManager>();
        if (sceneManager == null)
        {
            Debug.LogError("Level3SceneManager not found in the scene.");
        }

        startingPosition = transform.position;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;

            // Handle horizontal flipping
            if ((direction.x < 0 && isFacingRight) || (direction.x > 0 && !isFacingRight))
            {
                Flip();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lorax"))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            // Notify the scene manager of the collision
            if (sceneManager != null)
            {
                sceneManager.HitByOnceler();
            }

            // Randomize spawn position after collision with Lorax
            float randomX = Random.Range(randomSpawnRangeX.x, randomSpawnRangeX.y);
            float randomY = Random.Range(randomSpawnRangeY.x, randomSpawnRangeY.y);
            transform.position = new Vector3(randomX, randomY, transform.position.z);
        }
    }

    // Function to flip the Onceler horizontally
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Flip the x scale to create the flip effect
        transform.localScale = localScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth = 3; // Set starting health to 3 for 3 hearts
    public float currentHealth { get; private set; }

    private Healthbar healthbar; // Reference to Healthbar script

    public void Awake()
    {
        currentHealth = startingHealth;
        healthbar = FindObjectOfType<Healthbar>(); // Find Healthbar in the scene
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        Debug.Log($"Current Health: {currentHealth}"); // Debug line to see current health

        if (healthbar != null)
        {
            healthbar.UpdateHeartUI((int)currentHealth); // Update UI based on current health
        }

        if (currentHealth > 0)
        {
            // player hurt
            Debug.Log("Player hurt, current health: " + currentHealth);
        }
        else
        {
            // player dead
            Debug.Log("Player is dead");
            GameOver(); // Call the GameOver method when health reaches 0
        }
    }

    private void GameOver()
    {
        // Load the GameOver scene
        SceneManager.LoadScene("GameOver"); // Ensure "GameOver" matches the scene name in your project
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Axe") || other.CompareTag("Onceler")) // Check for Axe or Onceler collision
        {
            TakeDamage(1); // Call TakeDamage with 1 heart worth of damage
        }
    }
}

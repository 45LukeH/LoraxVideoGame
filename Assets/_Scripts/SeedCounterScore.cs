using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class SeedCounterScore : MonoBehaviour
{
    public int scoreValue = 0; // Tracks score
    private TextMeshProUGUI scoreText; // Reference to the UI TextMeshPro component for displaying score
    public GameObject lorax; // Reference to the Lorax GameObject

    void Start()
    {
        // Locate ScoreText UI component (this object)
        scoreText = GetComponent<TextMeshProUGUI>();

        if (scoreText != null)
        {
            UpdateScoreText(); // Initialize score display to "Seeds: 0"
        }
        else
        {
            Debug.LogError("ScoreText could not be found! Please check the component.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ThneedSeed") && lorax != null) // Check if the collided object is a ThneedSeed
        {
            // Check if the Lorax object is the one colliding
            if (other.gameObject.GetComponent<ThneedSeed>().isCollectedBy(lorax))
            {
                scoreValue += 1; // Increment score by 1
                UpdateScoreText(); // Update the UI text
                Destroy(other.gameObject); // Optional: Destroy the seed after collection
            }
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Seeds: " + scoreValue.ToString(); // Update the score text display
        }
    }
}

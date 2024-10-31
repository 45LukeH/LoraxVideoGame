using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SceneManagerScript : MonoBehaviour
{
    public int targetSeedCount = 20; // The target number of seeds to collect
    private int currentSeedCount = 0; // Tracks the current number of seeds collected

    void Start()
    {
        // Initialize seed count (if needed)
        currentSeedCount = 0;
    }

    void OnEnable()
    {
        // Subscribe to the event when a seed is collected
        SeedCounterScore.OnSeedCollected += IncrementSeedCount;
    }

    void OnDisable()
    {
        // Unsubscribe from the event
        SeedCounterScore.OnSeedCollected -= IncrementSeedCount;
    }

    void IncrementSeedCount()
    {
        currentSeedCount++;

        // Check if the Lorax has collected enough seeds
        if (currentSeedCount >= targetSeedCount)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // Load the next scene (level 3)
        SceneManager.LoadScene("Level 3"); // Replace "Level3" with the actual name of your level 3 scene
    }
}

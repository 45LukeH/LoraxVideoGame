using UnityEngine;

public class ThneedSeed3: MonoBehaviour
{
    // Reference to Level3SceneManager
    private Level3SceneManager level3SceneManager;

    void Start()
    {
        // Locate the Level3SceneManager in the scene
        level3SceneManager = FindObjectOfType<Level3SceneManager>();
        if (level3SceneManager == null)
        {
            Debug.LogError("Level3SceneManager not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lorax"))
        {
            level3SceneManager.CollectThneedSeed(); // Call the method to collect a ThneedSeed
            Destroy(gameObject); // Destroy the ThneedSeed GameObject after collection
        }
    }
}

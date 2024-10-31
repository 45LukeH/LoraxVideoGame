using UnityEngine;

public class ThneedSeedCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lorax"))
        {
            // Find SceneManagerController and update ThneedSeed count
            Level2SceneManager sceneManager = GameObject.FindObjectOfType<Level2SceneManager>();
            if (sceneManager != null)
            {
                sceneManager.CollectThneedSeed();
            }
            else
            {
                Debug.LogError("SceneManagerController not found in the scene.");
            }

            Destroy(gameObject); // Destroy the ThneedSeed after collision
        }
    }
}

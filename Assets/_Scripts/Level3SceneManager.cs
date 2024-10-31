using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3SceneManager : MonoBehaviour
{
    private int thneedSeedCount = 0; // Tracks collected ThneedSeeds
    private int oncelerHitCount = 0; // Tracks collisions with Onceler

    public void CollectThneedSeed()
    {
        thneedSeedCount++;
        Debug.Log("ThneedSeed collected. Total count: " + thneedSeedCount);

        if (thneedSeedCount >= 10)
        {
            Debug.Log("All ThneedSeeds collected! Loading GameWin scene...");
            LoadGameWinScene(); // Call the load scene method here
        }
    }

    public void HitByOnceler()
    {
        oncelerHitCount++;
        Debug.Log("Hit by Onceler. Total hits: " + oncelerHitCount);

        if (oncelerHitCount >= 3)
        {
            Debug.Log("Lorax hit by Onceler 3 times. Loading GameOver scene...");
            SceneManager.LoadScene("GameOver");
        }
    }

    private void LoadGameWinScene()
    {
        SceneManager.LoadScene("GameWin"); // Load the GameWin scene
    }
}

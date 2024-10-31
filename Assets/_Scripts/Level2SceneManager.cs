using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2SceneManager : MonoBehaviour
{
    private int thneedSeedCount = 0;
    private int axeHitCount = 0;

    public void CollectThneedSeed()
    {
        thneedSeedCount++;
        Debug.Log("ThneedSeed collected. Total count: " + thneedSeedCount);

        if (thneedSeedCount >= 20)
        {
            Debug.Log("Loading Level 3...");
            SceneManager.LoadScene("Level 3");
        }
    }

    public void HitByAxe()
    {
        axeHitCount++;
        Debug.Log("Hit by Axe. Total hits: " + axeHitCount);

        if (axeHitCount >= 3)
        {
            Debug.Log("Loading GameOver...");
            SceneManager.LoadScene("GameOver");
        }
    }
}

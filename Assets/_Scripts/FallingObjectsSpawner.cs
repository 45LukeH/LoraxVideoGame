using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectsSpawner : MonoBehaviour
{
    public GameObject thneedSeedPrefab;
    public GameObject axePrefab;
    public float spawnInterval;
    public float minX;
    public float maxX;
    public float spawnY;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            GameObject objectToSpawn;
            // 75% chance of seed to fall, 25% for axe
            if (Random.value > 0.75f)
            {
                objectToSpawn = thneedSeedPrefab;
            }
            else
            {
                objectToSpawn = axePrefab;
            }
            float randomX = Random.Range(minX, maxX);
            Vector2 spawnPosition = new Vector2(randomX, spawnY);
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

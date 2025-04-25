using UnityEngine;

public class RainSpawner : MonoBehaviour
{
    public GameObject rainDropPrefab;
    public float spawnInterval = 1f;
    public float xRange = 8f;

    void Start()
    {
        // Debug.Log("RainSpawner: Starting with interval " + spawnInterval + " and range " + xRange);
        InvokeRepeating("SpawnRainDrop", 1f, spawnInterval);
    }

    void SpawnRainDrop()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 6, 0);
        // Debug.Log("RainSpawner: Spawning raindrop at position " + spawnPos);
        GameObject rainDrop = Instantiate(rainDropPrefab, spawnPos, Quaternion.identity);
        // Debug.Log("RainSpawner: Raindrop spawned with ID: " + rainDrop.GetInstanceID());
    }
}

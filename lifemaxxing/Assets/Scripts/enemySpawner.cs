using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefab;

    [SerializeField]
    private float _minimumSpawnTime;

    [SerializeField]
    private float _maximumSpawnTime;

    private float _timeUntilSpawn;

    public Camera playerCamera;   // Assign your main camera in the Inspector
    public float spawnDistance = 1.0f;

    public float margin = 1f;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            GetRandomEdgePosition();
            SpawnRandomObject(_enemyPrefab[Random.Range(0, _enemyPrefab.Length - 1)]);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }

    public Vector3 GetRandomEdgePosition()
    {
        // Get camera bounds in world coordinates
        float zPosition = 0; // Assuming a 2D game, keep Z fixed
        Vector3 bottomLeft = playerCamera.ViewportToWorldPoint(new Vector3(0, 0, zPosition));
        Vector3 topRight = playerCamera.ViewportToWorldPoint(new Vector3(1, 1, zPosition));

        // Determine camera bounds
        float minX = bottomLeft.x;
        float maxX = topRight.x;
        float minY = bottomLeft.y;
        float maxY = topRight.y;

        // Randomly choose an edge
        int edge = Random.Range(0, 4); // 0 = left, 1 = right, 2 = top, 3 = bottom
        Vector3 spawnPosition = Vector3.zero;

        switch (edge)
        {
            case 0: // Left edge
                spawnPosition = new Vector3(minX - margin, Random.Range(minY, maxY), zPosition);
                break;
            case 1: // Right edge
                spawnPosition = new Vector3(maxX + margin, Random.Range(minY, maxY), zPosition);
                break;
            case 2: // Top edge
                spawnPosition = new Vector3(Random.Range(minX, maxX), maxY + margin, zPosition);
                break;
            case 3: // Bottom edge
                spawnPosition = new Vector3(Random.Range(minX, maxX), minY - margin, zPosition);
                break;
        }

        return spawnPosition;
    }

    void SpawnRandomObject(GameObject prefab)
    {
        // Get a random position near the camera edges
        Vector3 spawnPosition = GetRandomEdgePosition();

        // Instantiate the object at the calculated position
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

}

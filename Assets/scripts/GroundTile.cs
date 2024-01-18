using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindFirstObjectByType<GroundSpawner>();
        SpawnObstacle();
     }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();

        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        int obstacleSpawnindex = UnityEngine.Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnindex).transform;
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}

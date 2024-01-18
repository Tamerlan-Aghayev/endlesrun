using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject goundTile;
    Vector3 nextSpawnPoint;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnTile()
    {
       GameObject temp= Instantiate(goundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint=temp.transform.GetChild(1).transform.position;

    }
}

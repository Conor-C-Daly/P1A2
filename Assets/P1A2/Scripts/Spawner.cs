using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject asteroid;

    private int entitiesInScene;
    private int maxEntities; // Maximum amount of entities allowed in the scene at any given time

    private Vector3 spawnPos;
    [SerializeField] float maxSpawnPosWidth;

    [SerializeField] float spawnTimer = 3;

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0 )
        {
            spawnTimer = 3;
        }
    }

    private void FindSpawnPos()
    {
        spawnPos = new Vector3(Random.Range(-maxSpawnPosWidth, maxSpawnPosWidth), 7, 0);
    }

    private void SpawnAsteroid() /// heheh that rhymes
    {
        FindSpawnPos();
    }
}

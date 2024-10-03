using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject asteroid;

    private int entitiesInScene; // Current amount of entities in scene
    private int maxEntities; // Maximum amount of entities allowed in the scene at any given time

    private Vector3 spawnPos;
    [SerializeField] float maxSpawnPosWidth;

    [SerializeField] float spawnTimer = 3; // Counts down from 3 seconds, spawning a new enemy at 0

    // Update is called once per frame
    void Update()
    {
        // Spawn timer counts down from 3, spawns an asteroid at zero, and then resets
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            SpawnAsteroid();
            spawnTimer = 3;
        }
    }

    // Find a new position within bounds of the map
    private void FindSpawnPos()
    {
        
        spawnPos = new Vector3(Random.Range(-maxSpawnPosWidth, maxSpawnPosWidth), 7, 0);
    }

    private void SpawnAsteroid() /// private void SpawnAsteroid heheh that rhymes
    {
        FindSpawnPos();
        // Spawn an asteroid at the found spawn position
        GameObject go = Instantiate(asteroid, spawnPos, Quaternion.identity);
        // Make the asteroids move downwards from the top of the map
        go.GetComponent<Rigidbody2D>().AddForce(-transform.up * 2, ForceMode2D.Impulse);
    }
}

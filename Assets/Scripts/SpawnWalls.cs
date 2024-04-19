using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float minSpawnIntervalMilliseconds = 2000f;
    public float maxSpawnIntervalMilliseconds = 3500f;
    private float timeUntilNextSpawn;

    void Start()
    {
        timeUntilNextSpawn = Random.Range(minSpawnIntervalMilliseconds, maxSpawnIntervalMilliseconds);
    }

    void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime * 1000;

        if (timeUntilNextSpawn <= 0f)
        {
            SpawnObject();
            timeUntilNextSpawn = Random.Range(minSpawnIntervalMilliseconds, maxSpawnIntervalMilliseconds);
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnerPosition = transform.position;
        Instantiate(objectToSpawn, new Vector3(spawnerPosition.x, 2.5f, spawnerPosition.z), Quaternion.identity);
    }
}

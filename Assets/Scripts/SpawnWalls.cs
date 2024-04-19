using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnIntervalMilliseconds = 2000f;
    private float timeSinceLastSpawn;

    void Start()
    {
        timeSinceLastSpawn = 0f;
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime * 1000;

        if (timeSinceLastSpawn >= spawnIntervalMilliseconds)
        {
            SpawnObject();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnerPosition = transform.position;
        Instantiate(objectToSpawn, new Vector3(spawnerPosition.x, 2.5f, spawnerPosition.z), Quaternion.identity);
    }
}

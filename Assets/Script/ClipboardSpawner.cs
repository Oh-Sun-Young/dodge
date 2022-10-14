using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardSpawner : MonoBehaviour
{
    public GameObject[] clipboardPrefab;
    float spawnRatemin = 0.5f;
    float spawnRatemax = 3f;
    Vector3 spawnStart;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
    }
    void Update()
    {
        spawnRatemin = 0.5f - Data.stage * 0.01f;
        spawnRatemax = 3f - Data.stage * 0.1f;
        spawnRate = Random.Range(spawnRatemin, spawnRatemax);
        if (Data.isGame)
        {
            timeAfterSpawn += Time.deltaTime;
            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0f;
                int typePrefab = Random.Range(0, clipboardPrefab.Length);
                spawnStart = transform.position;
                transform.rotation = Quaternion.Euler(0,Random.Range(-25,25),0);
                Instantiate(clipboardPrefab[typePrefab], spawnStart, transform.rotation);
            }
        }
    }
}

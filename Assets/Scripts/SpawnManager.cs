using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerUpPrefab;
    void Start()
    {
        Instantiate(powerUpPrefab, SpawnGenerate(), powerUpPrefab.transform.rotation);
        SpawnEnemyWawe(waveNumber);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWawe(waveNumber);
            Instantiate(powerUpPrefab, SpawnGenerate(), powerUpPrefab.transform.rotation);
        }
    }

    private Vector3 SpawnGenerate()
    {
        float spawnPozX = Random.Range(spawnRange, -spawnRange);
        float spawnPozZ = Random.Range(spawnRange, -spawnRange);
        Vector3 randomPoz = new Vector3(spawnPozX, 0.025f, spawnPozZ);

        return randomPoz;
    }

    void SpawnEnemyWawe(int enemysToSpawn)
    {
        for(int i = 0; i < enemysToSpawn; i++)
        {
            Instantiate(enemyPrefab, SpawnGenerate(), enemyPrefab.transform.rotation);
        
        }
    }
}

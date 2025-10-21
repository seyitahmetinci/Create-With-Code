using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9f;
    public float numberOfEnemies = 0;
    private int waveNumber = 1;
    public GameObject powerUpObject;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerUpObject, GenerateSpawnPosition(), powerUpObject.transform.rotation);

        SpawnEnemyWave(3);
        
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {
        numberOfEnemies = FindObjectsOfType<Enemy>().Length;

        if(numberOfEnemies == 0)
        {
            Instantiate(powerUpObject, GenerateSpawnPosition(), powerUpObject.transform.rotation);
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnRangeX = Random.Range(-spawnRange, spawnRange);
        float spawnRangeZ = Random.Range(-spawnRange, spawnRange);

        Vector3 RandomPos = new Vector3(spawnRangeX, 0, spawnRangeZ);

        return RandomPos; 
    }
}

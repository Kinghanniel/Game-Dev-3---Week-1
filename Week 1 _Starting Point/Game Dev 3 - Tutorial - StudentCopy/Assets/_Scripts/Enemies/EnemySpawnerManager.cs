using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float delayBetweenSpawns;
    [SerializeField] int numberOfEnemiesSpawned;
    [SerializeField] float delayBetweenWaves;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] EnemyData[] enemyData;
    [SerializeField] int wavesNumber;
    private int currentWaveCount = 0;

    public void SpawnLogic()
    {
        StartCoroutine(SpawnWave());   
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < numberOfEnemiesSpawned; i++)
        {
            int randomInterger = Random.Range(0, spawnPoints.Length -1);
            GameObject spawnedShip = Instantiate(enemyPrefab, spawnPoints[randomInterger]);
            spawnedShip.GetComponent<EnemyVisual>().enemyData = enemyData[currentWaveCount];
            spawnedShip.GetComponent<EnemyMovement>().enemyData = enemyData[currentWaveCount];
            spawnedShip.GetComponent<EnemyLife>().enemyData = enemyData[currentWaveCount];
            yield return new WaitForSeconds(delayBetweenWaves);
        }


        
        currentWaveCount++;
        if (currentWaveCount > enemyData.Length - 1)
        {
            currentWaveCount = 0;
        }

        yield return new WaitForSeconds(delayBetweenWaves);
        StartCoroutine(SpawnWave());

    }

}

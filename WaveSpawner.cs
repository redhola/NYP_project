using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform spawnPoint1;
    private GameManager gameManager;
    public static int EnemiesAlive = 0;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;

    private void Update()
    {
        if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waves.Length)
		{
			
			this.enabled = false;
		}

		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;
        
    }

    IEnumerator SpawnWave()
    {
        
        PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];
        

        foreach(EnemyBluePrint enemy in wave){
            for(int i=0;i<enemy.Count;i++){
                SpawnEnemy(enemy.Enemy);
                EnemiesAlive++;
                yield return new WaitForSeconds(enemy.Rate);
            }
        }
        waveIndex++;
        

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint1.position, spawnPoint1.rotation);
    }

}
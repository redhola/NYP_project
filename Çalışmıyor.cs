using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float waveCountdown = 2f;
    private float searchCountdown = 1f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    private SpawnState state = SpawnState.COUNTING;

    private void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }

        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
         if (state == SpawnState.WAITING)
         {
             if (!EnemyIsAlive())
             {
                 WaveCompleted();
             }
             else
             {
                 return;
             }
         }

        if (waveCountdown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave());
                waveCountdown = timeBetweenWaves;
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }


        waveCountdownText.text = Mathf.Round(waveCountdown).ToString();
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (waveIndex + 1 > waves.Length - 1)
        {
            waveIndex = 0;
            Debug.Log("ALL WAVES COMPLETE! Looping..");

        }
        else
        {
            waveIndex++;
        }
    }
    
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave()
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        state = SpawnState.WAITING;

        yield break;
    }
    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy()
    {
        Transform _sp = spawnPoint;
        Instantiate(enemyPrefab, _sp.position, _sp.rotation);
    }
}
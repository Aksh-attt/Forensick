using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeBetweenWaves = 15f;
    [SerializeField] private int enemiesPerWave = 3;
    [SerializeField] private float spawnRadius = 10f;

    private float waveTimer = 0f;
    private int currentWave = 0;

    void Update()
    {
        waveTimer += Time.deltaTime;

        if (waveTimer >= timeBetweenWaves)
        {
            waveTimer = 0f;
            SpawnWave();
        }
    }

    void SpawnWave()
{
    currentWave++;
    int enemiesToSpawn = enemiesPerWave + currentWave;

    for (int i = 0; i < enemiesToSpawn; i++)
    {
        // Player ke around but screen ke bahar spawn karo
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = (Vector2)Camera.main.transform.position + randomDir * spawnRadius;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
}
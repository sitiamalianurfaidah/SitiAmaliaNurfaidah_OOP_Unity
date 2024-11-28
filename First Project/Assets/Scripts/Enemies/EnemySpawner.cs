using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public Enemy spawnedEnemy;

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;
    private int totalKillWave = 0;

    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public CombatManager combatManager;

    public bool isSpawning = false;

public void StartSpawning()
{
    isSpawning = true; // Mulai proses spawning
    StartCoroutine(SpawnEnemies()); // Mulai coroutine spawning musuh
}

    private IEnumerator SpawnEnemies()
    {
        while (isSpawning)
        {
            if (totalKill >= minimumKillsToIncreaseSpawnCount)
            {
                spawnCount += spawnCountMultiplier;
                totalKill = 0;
                }

            for (int i = 0; i < spawnCount; i++)
            {
                Instantiate(spawnedEnemy, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void IncreaseKills(int kills)
    {
        totalKill += kills;
        totalKillWave += kills;

        if (totalKillWave >= minimumKillsToIncreaseSpawnCount)
        {
            spawnCount += spawnCountMultiplier;
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}

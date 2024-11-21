using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [Header("Enemy Spawners")]
    public EnemySpawner[] enemySpawners; // Daftar EnemySpawner yang akan digunakan

    [Header("Wave Settings")]
    public float timer = 0; // Timer untuk hitung mundur antar wave
    [SerializeField] private float waveInterval = 5f; // Interval antara setiap wave
    public int waveNumber = 1; // Nomor wave saat ini
    public int totalEnemies = 0; // Jumlah total musuh yang telah di-spawn

    private void Start()
    {
        // Memulai coroutine untuk menangani wave system
        StartCoroutine(WaveSystem());
    }

    private IEnumerator WaveSystem()
    {
        while (true)
        {
            // Tunggu sesuai dengan interval antar wave
            yield return new WaitForSeconds(waveInterval);
            
            // Lakukan tindakan untuk memulai wave baru
            StartWave();

            // Tunggu selama wave berjalan (sesuai waktu interval)
            yield return new WaitForSeconds(waveInterval);

            // Pindah ke wave berikutnya
            waveNumber++;
        }
    }

    private void StartWave()
    {
        // Reset totalEnemies setiap wave
        totalEnemies = 0;

        // Lakukan spawn musuh melalui semua enemy spawners
        foreach (var spawner in enemySpawners)
        {
            // Set spawnCount dan spawn musuh sesuai dengan waveNumber
            spawner.spawnCount = spawner.defaultSpawnCount + (waveNumber - 1); // Menambah jumlah spawn seiring bertambahnya wave
            spawner.StartSpawning(); // Memulai spawning
            totalEnemies += spawner.spawnCount; // Menambahkan totalEnemies
        }
    }

    public void StopCombat()
    {
        // Stop spawning pada semua spawner ketika combat dihentikan
        foreach (var spawner in enemySpawners)
        {
            spawner.StopSpawning();
        }
    }
}

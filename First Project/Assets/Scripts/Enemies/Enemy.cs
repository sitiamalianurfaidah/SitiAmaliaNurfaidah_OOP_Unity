using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int level;

    public UnityEvent enemyKilledEvent;
    public int pointsOnKill = 10; // Poin yang diberikan ketika musuh mati
    public PlayerPoints playerPoints; // Referensi ke skrip PlayerPoints

    private void Start()
    {
    enemyKilledEvent ??= new UnityEvent();
    playerPoints = FindObjectOfType<PlayerPoints>();
    }

    public void SetLevel(int level)
    {
    this.level = level;
    }

    public int GetLevel()
    {
    return level;
    }
    
    public void OnDestroy()
{
    enemyKilledEvent.Invoke();
    CombatManager combatManager = FindObjectOfType<CombatManager>();
    if (combatManager != null)
    {
        combatManager.totalEnemies--; // Mengurangi jumlah musuh yang tersisa
    }
}


    public void OnEnemyKilled(Enemy enemy)
{
    PlayerPoints playerPoints = FindObjectOfType<PlayerPoints>();
    if (playerPoints != null)
    {
        playerPoints.AddPoints(enemy.GetLevel());
    }
}
public void Die()
    {
        playerPoints.AddPoints(pointsOnKill); // Tambahkan poin ke pemain
        Destroy(gameObject); // Hancurkan musuh
    }

}
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] private float shootIntervalInSeconds = 3f;

    [Header("Bullets")]
    public Bullet bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    [Header("Bullet Pool")]
    private IObjectPool<Bullet> objectPool;

    private readonly bool collectionCheck = false;
    private readonly int defaultCapacity = 30;
    private readonly int maxSize = 100;
    private float timer;

    void Awake()
    {
        // Initialize Object Pool
        objectPool = new ObjectPool<Bullet>(
            CreateBullet,
            OnGetBullet,
            OnReleaseBullet,
            OnDestroyBullet,
            collectionCheck,
            defaultCapacity,
            maxSize
        );
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootIntervalInSeconds)
        {
            Shoot();
            timer = 0f;
        }
    }

    private Bullet CreateBullet()
    {
        Bullet newBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        newBullet.bulletPool = objectPool;
        newBullet.transform.parent = transform;
        return newBullet;
    }
    
    private void OnGetBullet(Bullet bullet)
{
    bullet.gameObject.SetActive(true);
    
    Debug.Log("Bullet spawned at: " + bulletSpawnPoint.position); // Tambahkan log ini
}

    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false); // Deactivate Bullet when returned to pool
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        //Destroy(bullet.gameObject); // Destroy Bullet if the pool is destroyed
    }
    
    private void Shoot()
{
    Bullet spawnedBullet = objectPool.Get();
    if (spawnedBullet != null)
    {
        Debug.Log("Shooting Bullet"); // Debug here to see if Shoot() is called
    }
    else
    {
        Debug.LogError("Failed to get a bullet from the pool.");
    }
}


    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public float speed = 2f;
    public Bullet bulletPrefab;
    public Transform bulletSpawnPoint;
    private float shootInterval = 2f;
    private float shootTimer;

    void Update()
    {
        // Implementasi logika Boss, misalnya bergerak lambat ke bawah
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Tembak Bullet sesuai interval
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }
    
    void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = Vector2.down * bullet.bulletSpeed;
        }
    }
}


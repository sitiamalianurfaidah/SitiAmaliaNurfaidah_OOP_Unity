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
    private Vector2 direction;

    void Start()
    {
        // Atur arah awal (ke kanan)
        direction = Vector2.right;
    }

    void Update()
    {
        // Gerakkan EnemyBoss ke kanan atau kiri
        transform.Translate(direction * speed * Time.deltaTime);

        // Balik arah jika mencapai batas layar
        if (transform.position.x > 8)
        {
            direction = Vector2.left; // Gerak ke kiri
        }
        else if (transform.position.x < -8)
        {
            direction = Vector2.right; // Gerak ke kanan
        }

        // Logika menembak
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
        bullet.SetDirection(Vector2.down);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = Vector2.down * bullet.bulletSpeed; // Tembakan ke bawah
        }
    }
}

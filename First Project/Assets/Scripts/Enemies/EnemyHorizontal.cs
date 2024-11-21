using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontal : Enemy
{
    public float speed = 5f;
    private Vector2 direction;

    void Start()
    {
        // Tentukan posisi awal dan arah gerakan horizontal
        transform.position = new Vector2(Random.Range(-10, 10), transform.position.y);
        direction = Vector2.right; // Default: bergerak ke kanan
    }

    void Update()
    {
        // Gerakkan Enemy sesuai arah
        transform.Translate(direction * speed * Time.deltaTime);

        // Ubah arah jika keluar dari layar horizontal
        if (transform.position.x > 12)
        {
            direction = Vector2.left; // Berbalik ke kiri
        }
        else if (transform.position.x < -12)
        {
            direction = Vector2.right; // Berbalik ke kanan
        }
    }
}

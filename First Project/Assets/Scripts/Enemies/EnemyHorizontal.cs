using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontal : Enemy
{
    public float speed = 5f;
    private Vector2 direction;

    void Start()
    {
        // Tentukan arah spawn dari kiri atau kanan secara acak
        if (Random.value > 0.5f)
        {
            transform.position = new Vector2(-10, transform.position.y); // spawn dari kiri
            direction = Vector2.right; // bergerak ke kanan
        }
        else
        {
            transform.position = new Vector2(10, transform.position.y); // spawn dari kanan
            direction = Vector2.left; // bergerak ke kiri
        }
    }

    void Update()
    {
        // Gerakkan EnemyHorizontal dalam arah yang ditentukan
        transform.Translate(direction * speed * Time.deltaTime);

        // Ketika Enemy sudah keluar layar, balik arah gerakan
        if (transform.position.x > 12 || transform.position.x < -12)
        {
            direction = -direction;
        }
    }
}

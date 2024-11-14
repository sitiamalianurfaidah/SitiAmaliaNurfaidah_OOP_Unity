using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForward : Enemy
{
    public float speed = 5f;

    void Start()
    {
        transform.position = new Vector2(Random.Range(-8, 8), 10); // spawn dari atas
    }

    void Update()
    {
        // Gerakkan Enemy ke bawah
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Jika sudah di luar layar, hapus atau reset posisi
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}


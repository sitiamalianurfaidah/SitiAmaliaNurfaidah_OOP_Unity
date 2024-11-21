using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForward : Enemy
{
    public float speed = 5f;
    private Vector2 direction;

    void Start()
    {
        transform.position = new Vector2(Random.Range(-8, 8), 10); // spawn dari atas
        direction = Vector2.down;
    }

    void Update()
    {
        // Gerakkan Enemy sesuai arah
        transform.Translate(direction * speed * Time.deltaTime);

        // Jika sudah di luar layar, ubah arah
        if (transform.position.y < -10)
        {
            direction = Vector2.up;
        }
        else if (transform.position.y > 10)
        {
            direction = Vector2.down;
        }
    }
}

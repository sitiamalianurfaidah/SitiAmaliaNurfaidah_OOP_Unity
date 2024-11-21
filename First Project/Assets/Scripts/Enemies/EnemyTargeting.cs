using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : Enemy
{
    public float speed = 2f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        // Hitung arah ke Player
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        // Hapus Enemy jika bersentuhan dengan Player
        if (Vector2.Distance(transform.position, player.position) < 0.5f)
        {
            Destroy(gameObject);
        }
    }
}


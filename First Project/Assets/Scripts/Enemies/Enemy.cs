using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int level = 1; // Tingkat kesulitan enemy

    // Tambahkan method atau property dasar di sini sesuai kebutuhan
    void Update()
{
    // Jika player berada di posisi tertentu, gunakan ini agar musuh menghadap Player
    Vector3 playerPosition = GameObject.FindWithTag("Player").transform.position;
    transform.LookAt(playerPosition);
}

}


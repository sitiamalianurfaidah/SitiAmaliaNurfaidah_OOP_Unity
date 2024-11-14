using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20f;
    public int damage = 10;
    private Rigidbody2D rb;
    public IObjectPool<Bullet> bulletPool;

    public void SetPool(IObjectPool<Bullet> pool)
    {
        bulletPool = pool;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Function to launch the bullet
    public void FixedUpdate()
    {
        Debug.Log("Launching Bullet with speed: " + bulletSpeed);
        rb.velocity = Vector2.up * bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
    private void OnBecameInvisible()
    {
        if (bulletPool != null)
        {
            bulletPool.Release(this);
        }
    }


    private void OnDisable()
    {
        // Reset velocity when bullet is disabled to avoid issues when retrieved from the pool
        rb.velocity = Vector2.zero;
    }
}



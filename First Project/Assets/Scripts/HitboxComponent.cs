using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    private HealthComponent health;

    void Start()
    {
        health = GetComponent<HealthComponent>();
    }

    // Damage overload to receive Bullet
    public void Damage(Bullet bullet)
    {
        if (health != null)
        {
            health.Subtract(bullet.damage); // Assume bullet has a damage property
        }
    }

    // Damage overload to receive integer damage
    public void Damage(int damage)
    {
        if (health != null)
        {
            health.Subtract(damage);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    private int health;

    void Start()
    {
        health = maxHealth; // Set health to maxHealth at start
    }

    public int GetHealth()
    {
        return health;
    }

    public void Subtract(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); // Destroy object if health <= 0
        }
    }
}

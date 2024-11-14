using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    public Bullet bulletPrefab; // Set this to the bullet prefab in the Inspector
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(gameObject.tag))
            return; // Skip if tags are the same

        HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
        if (hitbox != null)
        {
            hitbox.Damage(damage); // Deal damage if the other object has a HitboxComponent
        }
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            InvincibilityComponent invincibility = other.GetComponent<InvincibilityComponent>();
            if (invincibility != null && !invincibility.isInvincible)
            {
                invincibility.StartInvincibility();
                // Bisa menambahkan logika lain untuk memberikan damage, dll.
            }
        }
    }
}


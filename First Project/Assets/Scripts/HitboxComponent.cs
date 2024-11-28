using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(HealthComponent))]
public class HitboxComponent : MonoBehaviour
{
    private HealthComponent healthComponent;
    private InvincibilityComponent flashComponent;
    private void Start()
    {
        flashComponent = GetComponent<InvincibilityComponent>();
        healthComponent = GetComponent<HealthComponent>();
    }
    
    public void Damage(int damage)
    {
        if (healthComponent != null && (flashComponent == null || !flashComponent.isInvincible))
        {
            healthComponent.Subtract(damage);
        }
    }

    public void Damage(Bullet bullet)
    {
        if (healthComponent != null && (flashComponent == null || !flashComponent.isInvincible))
        {
            healthComponent.Subtract(bullet.damage);
        }
    }
}
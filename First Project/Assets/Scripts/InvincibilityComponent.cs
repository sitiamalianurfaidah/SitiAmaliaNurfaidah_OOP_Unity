using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityComponent : MonoBehaviour
{
    [SerializeField] private int blinkingCount = 7;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private Material blinkMaterial;
    
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    public bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    // Enumerator for blinking effect
    public IEnumerator BlinkEffect()
    {
        for (int i = 0; i < blinkingCount; i++)
        {
            spriteRenderer.material = blinkMaterial;  // Change to blink material
            yield return new WaitForSeconds(blinkInterval);
            spriteRenderer.material = originalMaterial;  // Restore original material
            yield return new WaitForSeconds(blinkInterval);
        }
        isInvincible = false;  // After blinking, set invincible to false
    }

    // Method to be called by other classes
    public void StartInvincibility()
    {
        if (!isInvincible)
        {
            isInvincible = true;
            StartCoroutine(BlinkEffect());  // Start the blinking effect coroutine
        }
    }
}

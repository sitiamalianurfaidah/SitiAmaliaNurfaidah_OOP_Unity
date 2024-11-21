using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityComponent : MonoBehaviour
{
    [SerializeField] private int blinkingCount = 7;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private Material blinkMaterial;
    
    private bool isPlayer = false;
    private Material originalMaterial;
    public bool isInvincible = false;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        isPlayer = gameObject.CompareTag("Player");

        if (isPlayer)
        {
            Transform shipTransform = transform.Find("Ship");
            if (shipTransform != null)
            {
                spriteRenderer = shipTransform.GetComponent<SpriteRenderer>();
                if (spriteRenderer == null)
                {
                    Debug.LogError("Ship child object doesn't have a SpriteRenderer!");
                }
            }
            else
            {
                Debug.LogError("Player doesn't have a child named 'Ship'!");
            }
        }
        else
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer != null)
        {
            originalMaterial = spriteRenderer.material;
        }
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

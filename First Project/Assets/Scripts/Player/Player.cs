using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    PlayerMovement playerMovement;
    Animator animator;
    // New field to track if the player has a weapon
    private bool hasWeapon = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        playerMovement.Move();
    }

    void LateUpdate()
    {
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }
    // New method to check if the player has a weapon
    public bool HasWeapon()
    {
        return hasWeapon;
    }

    // Optional: Method to set whether the player has a weapon
    public void PickUpWeapon()
    {
        hasWeapon = true;
    }

    public void DropWeapon()
    {
        hasWeapon = false;
    }
}

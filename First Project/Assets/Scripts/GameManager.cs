using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public LevelManager LevelManager { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        LevelManager = GetComponentInChildren<LevelManager>();
        
        if (LevelManager == null)
        {
            Debug.LogError("LevelManager component not found in GameManager.");
        }
        DontDestroyOnLoad(gameObject);

        //Ensure the Camera is not destroyed
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            DontDestroyOnLoad(mainCamera.gameObject);
        }
        else
        {
            Debug.LogError("Main Camera not found.");
        }
    }
}

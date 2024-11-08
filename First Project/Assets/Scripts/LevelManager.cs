using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Awake()
    {
        animator.enabled = false;
        if (animator == null)
        {
            Debug.LogError("Animator component not assigned to LevelManager.");
        }
    }

    IEnumerator LoadSceneAsync(string sceneName) 
    {
        animator.enabled = true;
        yield return new WaitForSeconds(1);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        animator.SetTrigger("Start"); // Trigger the scene transition animation

        if (Player.Instance != null)
        {
            Player.Instance.transform.position = new Vector3(0, -4.5f, 0);
        }
    }

    public void LoadScene(string sceneName) {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

}

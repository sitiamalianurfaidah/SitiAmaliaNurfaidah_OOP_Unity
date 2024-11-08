using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;
    Vector2 newPosition;
    private LevelManager levelManager;
    private Player player;
    public GameObject asteroid; 

    void Start()
    {
        // Initialize level manager and player references
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<Player>();
        ChangePosition();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        // Check if the player has a weapon
        if (GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Weapon>()!= null)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            asteroid.SetActive(true);
            transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, newPosition) < 0.5f)
            {
                ChangePosition();
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            asteroid.SetActive(false); // Sembunyikan asteroid jika pemain belum memiliki senjata

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelManager.LoadScene("Main");
        }
    }
    void ChangePosition() 
    {
        // Set a random position for the newPosition within screen bounds or a specified area
        float x = Random.Range(-5f, 5f); // Adjust these values as needed
        float y = Random.Range(-5f, 5f);
        newPosition = new Vector2(x, y);
    }
}

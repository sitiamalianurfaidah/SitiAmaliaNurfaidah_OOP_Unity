using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 maxSpeed;
    [SerializeField] private Vector2 timeToFullSpeed;
    [SerializeField] private Vector2 timeToStop;
    [SerializeField] private Vector2 stopClamp;

    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;
    private Rigidbody2D rb;

    private Vector2 screenBounds;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Hitung velocity, friction, dan stopFriction untuk masing-masing komponen x dan y
        moveVelocity = new Vector2(
            2 * maxSpeed.x / timeToFullSpeed.x,
            2 * maxSpeed.y / timeToFullSpeed.y
        );

        moveFriction = new Vector2(
            -2 * maxSpeed.x / Mathf.Pow(timeToFullSpeed.x, 2),
            -2 * maxSpeed.y / Mathf.Pow(timeToFullSpeed.y, 2)
        );

        stopFriction = new Vector2(
            -2 * maxSpeed.x / Mathf.Pow(timeToStop.x, 2),
            -2 * maxSpeed.y / Mathf.Pow(timeToStop.y, 2)
        );

        // Ambil batas layar berdasarkan ukuran kamera
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    public void Move()
    {
        // Ambil input gerakan dan arahkan ke moveDirection
        float moveInputX = Input.GetAxis("Horizontal");
        float moveInputY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(moveInputX, moveInputY);

        // Dapatkan gaya gesek berdasarkan kondisi
        Vector2 friction = GetFriction();

        // Update kecepatan berdasarkan input dan gesekan
        Vector2 velocity = rb.velocity;

        if (moveDirection != Vector2.zero)
        {
            // Jika ada input, tambah kecepatan ke arah input
            velocity.x = Mathf.Clamp(velocity.x + moveDirection.x * moveVelocity.x * Time.fixedDeltaTime, -maxSpeed.x, maxSpeed.x);
            velocity.y = Mathf.Clamp(velocity.y + moveDirection.y * moveVelocity.y * Time.fixedDeltaTime, -maxSpeed.y, maxSpeed.y);
        }
        else
        {
            // Jika tidak ada input, kurangi kecepatan dengan gaya gesek
            velocity.x = Mathf.MoveTowards(velocity.x, 0, Mathf.Abs(friction.x * Time.fixedDeltaTime));
            velocity.y = Mathf.MoveTowards(velocity.y, 0, Mathf.Abs(friction.y * Time.fixedDeltaTime));
        }

        rb.velocity = velocity;

        // Panggil MoveBound() untuk membatasi pergerakan
        MoveBound();
    }

    private Vector2 GetFriction()
    {
        // Hitung gaya gesek
        return moveDirection != Vector2.zero ? moveFriction * moveDirection : stopFriction * rb.velocity.normalized;
    }

    private void MoveBound()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -screenBounds.x, screenBounds.x);
        pos.y = Mathf.Clamp(pos.y, -screenBounds.y, screenBounds.y);
        transform.position = pos;
    }

    public bool IsMoving()
    {
        return rb.velocity.magnitude > 0.1f;
    }
}
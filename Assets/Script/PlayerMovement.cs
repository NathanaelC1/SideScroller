using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 3f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private PlayerAnimationHandler animationHandler;

    void Start()
    {
        // Ambil komponen Rigidbody2D dari objek player
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Temukan komponen PlayerAnimationHandler di objek yang sama atau parent/child
        animationHandler = GetComponent<PlayerAnimationHandler>();
        if (animationHandler == null)
        {
            Debug.LogError("PlayerAnimationHandler not found on Player.");
        }
    }

    private void SpriteFlip(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate()
    {
        // Menggerakan player ke kanan atau kiri menggunakan transform.translate
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
        SpriteFlip(horizontalInput);

        // Memanggil metode untuk mengatur animasi berjalan
        if (animationHandler != null)
        {
            animationHandler.SetWalking(Mathf.Abs(horizontalInput) > 0.01f);
        }

        // Mengaktifkan lompatan player jika player menyentuh tanah
        bool isGrounded = Mathf.Abs(rb.velocity.y) < 0.001f;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            if (animationHandler != null)
            {
                animationHandler.SetJumping(true);
            }
        }

        // Mengatur animasi jatuh jika kecepatan vertikal negatif
        if (animationHandler != null)
        {
            animationHandler.SetFalling(rb.velocity.y < 0);
            if (isGrounded)
            {
                animationHandler.SetJumping(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 3f;
    Vector2 moveInput;
    Rigidbody2D playerRigidbody2D;
    Animator playerAnimator;
    CapsuleCollider2D playerBodyCollider2D;
    BoxCollider2D playerFeetCollider2D;
    float gravityAtStart;
    bool isAlive = true;

    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerBodyCollider2D = GetComponent<CapsuleCollider2D>();
        playerFeetCollider2D = GetComponent<BoxCollider2D>();
        gravityAtStart = playerRigidbody2D.gravityScale;
    }

    void Update()
    {
        if (isAlive)
        {
            Run();
            FlipSprite();
            Climbing();
            Die();
        }
    }

    void OnMove(InputValue value)
    {
        if (isAlive)
        {
            moveInput = value.Get<Vector2>();
        }

    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, playerRigidbody2D.velocity.y);
        playerRigidbody2D.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(playerRigidbody2D.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(playerRigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRigidbody2D.velocity.x), 1f);
        }
    }

    void OnJump(InputValue value)
    {
        if (isAlive)
        {
            if (value.isPressed && playerFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                playerRigidbody2D.velocity += new Vector2(0f, jumpSpeed);
            }
        }
    }

    void Climbing()
    {
        if (playerFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            Vector2 playerVelocity = new Vector2(playerRigidbody2D.velocity.x, moveInput.y * climbSpeed);
            playerRigidbody2D.velocity = playerVelocity;
            bool playerHasClimbSpeed = Mathf.Abs(playerRigidbody2D.velocity.y) > Mathf.Epsilon;
            playerAnimator.SetBool("isClimbing", playerHasClimbSpeed);
            playerRigidbody2D.gravityScale = 0f;
        }
        else
        {
            playerRigidbody2D.gravityScale = gravityAtStart;
            playerAnimator.SetBool("isClimbing", false);
        }
    }

    void Die()
    {
        if (playerBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazard")))
        {
            isAlive = false;
            playerAnimator.SetTrigger("Die");
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}

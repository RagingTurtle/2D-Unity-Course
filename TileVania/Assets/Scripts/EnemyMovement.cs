using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D enemyRigidbody2D;
    void Start()
    {
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
    }

    void Run()
    {
        enemyRigidbody2D.velocity = new Vector2(moveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("bump");
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }
    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidbody2D.velocity.x)), 1f);
    }
}

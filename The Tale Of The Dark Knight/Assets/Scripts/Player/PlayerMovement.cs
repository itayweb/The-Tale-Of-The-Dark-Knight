using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckObj;
    [SerializeField] float groundCheckRadius;
    private Rigidbody2D rb;
    private float xAxis;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        ChangePlayerDirection();
    }

    void ChangePlayerDirection()
    {
        if (xAxis < 0 && isFacingRight)
        {
            FlipDirection();
        }

        else if (xAxis > 0 && !isFacingRight)
        {
            FlipDirection();
        }
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
        Jump();
    }

    void HorizontalMovement()
    {
        rb.velocity = new Vector2(xAxis * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsPlayerOnGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    bool IsPlayerOnGround()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(groundCheckObj.position, groundCheckRadius, groundLayer);
        if (groundCheck != null)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckObj.position, groundCheckRadius);
    }

    void FlipDirection()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}

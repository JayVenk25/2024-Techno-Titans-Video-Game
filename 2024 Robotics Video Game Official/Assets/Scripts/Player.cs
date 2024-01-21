using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool moveLeft;
    private bool moveRight;

    private float horizontalMove;
    public float speed = 5f;
    public float jumpForce = 5;
    public float delayBeforeDoubleJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveLeft = false;
        moveRight = false;
    }

    void Update()
    {
        if (moveLeft == true)
        {
            horizontalMove = -speed;

        }
        else if (moveRight == true)
        {
            horizontalMove = speed;

        }
        else
        {
            horizontalMove = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }

    public void jumpButton()
    {
        if (Feet.isGrounded == true)
        {
            Feet.isGrounded = false;
            rb.velocity = Vector2.up * jumpForce;
            Invoke("EnableDoubleJump", delayBeforeDoubleJump);
        }

        if (Feet.canDoubleJump == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            Feet.canDoubleJump = false;
        }
    }

    void EnableDoubleJump()
    {
        Feet.canDoubleJump = true;
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }
}

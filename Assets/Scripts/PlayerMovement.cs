using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed Settings")]
    [Range(0f, 20f)]
    public float runSpeed = 20f;
    public float movementSmoothing = 0.05f;
    public float jumpForce = 400f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer; 
    private Rigidbody2D rigibody2D;
    private float horizontalMove = 0f;
    private Vector3 currentVelocity;
    private float compensationSpeed = 10f;
    private bool facingRight = true;
    private bool jumpPressed = false;
    private bool isGrounded = false;
    private void Awake()
    {
        rigibody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = false;
        Collider2D[] groundColliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);
        for (int i = 0; i < groundColliders.Length; i++)
        {
            if(groundColliders[i].gameObject != this.gameObject)
            {
                isGrounded  = true;
            }
        }

        
        Move(horizontalMove * Time.fixedDeltaTime);
        if (horizontalMove > 0f && !facingRight)
        {
            Flip();
        } 
        else if (horizontalMove < 0f && facingRight)
        {
           Flip();
        
        }
    }

    private void Move(float _move)
    {
        Vector3 targetVelocity = new Vector2(_move* compensationSpeed, rigibody2D.velocity.y);
        rigibody2D.velocity = Vector3.SmoothDamp(rigibody2D.velocity, targetVelocity, ref currentVelocity, movementSmoothing);
        if (jumpPressed && isGrounded)
        {
            rigibody2D.AddForce(new Vector2(0f, jumpForce));
            jumpPressed = false;
            isGrounded = false;
        }

    }
    private void Flip()
    {
        facingRight = !facingRight;
            Vector3 targetScale = transform.localScale;
            targetScale.x *= -1;
            transform.localScale = targetScale;
    }
}

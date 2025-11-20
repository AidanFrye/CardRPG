using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldPlayerController : MonoBehaviour
{
    private Animator animator;
    private Vector2 input;
    private Rigidbody2D rb;

    //change movement for player and enemy to rb based movement and not transform based movement
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.speed = 0.4f;
        animator.Play("Idle");
    }

    public void FixedUpdate()
    {
        ProcessMovement();
    }

    public void ProcessMovement() 
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();
        rb.MovePosition(rb.position + input * Time.deltaTime);
    }
}

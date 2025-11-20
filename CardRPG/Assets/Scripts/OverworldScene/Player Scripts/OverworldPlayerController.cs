using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldPlayerController : MonoBehaviour
{
    private Animator animator;

    //change movement for player and enemy to rb based movement and not transform based movement
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        animator.speed = 0.4f;
        animator.Play("Idle");
    }

    public void Update()
    {
        ProcessMovement();
    }

    public void ProcessMovement() 
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 2 * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 2 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(2 * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy")) 
        {
            Debug.Log("starting battle");
        }
        Debug.Log("starting battle");
    }
}

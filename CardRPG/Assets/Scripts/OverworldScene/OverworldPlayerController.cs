using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldPlayerController : MonoBehaviour
{
    private Animator animator;

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
}

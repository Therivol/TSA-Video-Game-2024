using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    private Animator animator;

    Vector2 movement;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!Pause.isPaused) {
            ProcessInputs();
        }

    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void ProcessInputs() 
    {
        if (PlayerStats.playerStats.canMove) {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            float h = movement.x;
            float v = movement.y;
            float speed = movement.sqrMagnitude;

            animator.SetFloat("Horizontal", h);
            animator.SetFloat("Vertical", v);
            animator.SetFloat("Speed", speed);

            if (speed != 0) {
                animator.SetFloat("LastHorizontal", h);
                animator.SetFloat("LastVertical", v);
            }

            movement.Normalize();
        }
        else
        {
            movement = Vector2.zero;
            animator.SetFloat("Speed", 0f);
        }
        
    }
}

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

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

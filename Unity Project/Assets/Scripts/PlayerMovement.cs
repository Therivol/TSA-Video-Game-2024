using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    private Animator animator;

    Vector2 movement;

    [SerializeField] private GameObject garlicPrefab;
    [SerializeField] private Transform releasePoint;


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

        if (Input.GetMouseButtonDown(0)) {
            ThrowGarlic();
        }
    }

    private void ThrowGarlic() {

        animator.Play("Player_Throw", 0, 0f);
        
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePos - rb.position;

        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        releasePoint.rotation = Quaternion.Euler(0f, 0f, aimAngle);
        
        Instantiate(garlicPrefab, releasePoint.position, releasePoint.rotation);
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

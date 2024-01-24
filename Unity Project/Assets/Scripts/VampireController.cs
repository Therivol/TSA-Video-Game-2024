using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 2f;
    
    private Rigidbody2D rb;
    private Animator animator;

    private float health = 100f;

    Vector2 movement;

    [SerializeField] private GameObject batPrefab;
    [SerializeField] private GameObject vampirePoofPrefab;

    [SerializeField] private Transform target;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameManager.gameManager.vampTarget;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, target.position);
        Vector2 direction = (target.position - transform.position);

        movement = new Vector2(direction.x, direction.y);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        movement.Normalize();
    }


    public void TakeDamage(float amount) {
        health -= amount;
        if (health <= 0f) {
            Run();
        }
    }

    public void Run() 
    {
        float randomRot = Random.Range(0f, 360f);
        Instantiate(batPrefab, rb.position, Quaternion.Euler(0f, 0f, randomRot));
        Instantiate(vampirePoofPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

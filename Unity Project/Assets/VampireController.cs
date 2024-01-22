using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    private Animator animator;

    private float health = 100f;

    Vector2 movement;

    [SerializeField] private GameObject batPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2)) {
            TakeDamage(20);
        }
    }


    public void TakeDamage(float amount) {
        health -= amount;
        if (health <= 0f) {
            Run();
        }
    }

    void Run() 
    {
        float randomRot = Random.Range(0f, 360f);
        Instantiate(batPrefab, rb.position, Quaternion.Euler(0f, 0f, randomRot));
        Destroy(gameObject);
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

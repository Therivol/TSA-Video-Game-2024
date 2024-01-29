using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VampireController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 1.5f;
    
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private float health = 80f;

    Vector2 movement;

    [SerializeField] private GameObject batPrefab;
    [SerializeField] private GameObject vampirePoofPrefab;

    [SerializeField] private GameObject[] powerUps;

    private UnityEvent vampDeath = new UnityEvent();

    private Transform target;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        vampDeath.AddListener(GameManager.gameManager.VampDeath);

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameManager.gameManager.firstArea.transform;
        health *= GameManager.gameManager.waveMult * Random.Range(0.6f, 1.6f);
        moveSpeed *= GameManager.gameManager.waveMult * Random.Range(0.8f, 1.5f);
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
        if (health <= 0f && health + amount > 0) {
            Run();
        }
    }

    public void Run() 
    {
        RandomPowerUp();
        float randomRot = Random.Range(0f, 360f);
        Instantiate(batPrefab, rb.position, Quaternion.Euler(0f, 0f, randomRot));
        Instantiate(vampirePoofPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        vampDeath.Invoke();
    }

    public void RandomPowerUp() {
        if (Random.Range(0f, 1f) <= GameManager.gameManager.powerUpChance) {
            GameObject powerUp = powerUps[Random.Range(0, powerUps.Length - 1)];
            GameObject powerInstance = Instantiate(powerUp, transform.position, Quaternion.identity);
            Destroy(powerInstance, 8f);
        }
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void SetTarget(Transform newTarget) {
        target = newTarget;
    }
}

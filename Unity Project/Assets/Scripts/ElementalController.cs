using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalController : MonoBehaviour
{

    [SerializeField] private GameObject waterBoltPrefab;
    [SerializeField] private Transform releasePoint;
    [SerializeField] private Transform controller;

    private Animator animator;

    private Vector2 newLocation;

    private GameObject target;

    private float targetDist = 20f;
    private float lastAttack;
    private float lastMove;
    private float moveFreq = 6f;
    private float moveSpeed = 6f;

    private float moveRange = 3f;

    private bool moving = false;



    void Start() 
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Pause.isPaused) {
            return;
        }
        
        if (!moving) {
            if (Time.time - lastMove > moveFreq || Vector2.Distance(controller.position, transform.position) > 10f) {
                Move();
            }
            else if ((Time.time - lastAttack) > 1 / PlayerStats.playerStats.boltFreq) {
                Attack();
                lastAttack = Time.time;
            }
        }

        else if (Vector2.Equals(new Vector2(transform.position.x, transform.position.y), newLocation)) {
            moving = false;
            animator.SetFloat("LastHorizontal", 0);
            animator.SetFloat("LastVertical", 0);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, newLocation, moveSpeed * Time.deltaTime);
            Vector2 direction = newLocation - new Vector2(transform.position.x, transform.position.y);
            direction.Normalize();
            animator.SetFloat("LastHorizontal", direction.x);
            animator.SetFloat("LastVertical", direction.y);
        }

        
    }

    void Move() {
        moving = true;
        lastMove = Time.time;
        newLocation = new Vector2(Random.Range(-moveRange, moveRange) + controller.position.x, Random.Range(-moveRange, 0) + controller.position.y);
    }

    public void ThrowBolt(Transform towards) 
    {
        Vector2 aimDirection = new Vector2(towards.position.x, towards.position.y) - new Vector2(transform.position.x, transform.position.y);

        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        releasePoint.rotation = Quaternion.Euler(0f, 0f, aimAngle);
        
        Instantiate(waterBoltPrefab, releasePoint.position, releasePoint.rotation);
    }

    void newTarget() {
        GameObject[] vampires = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject vamp in vampires) {
            if (Vector3.Distance(vamp.transform.position, controller.transform.position) <= targetDist) {
                target = vamp;
                break;
            }
        }
    }
    
    void Attack() {
        if (target == null) {
            newTarget();
        }
        if (target) {
            ThrowBolt(target.transform);
        }
    }
}

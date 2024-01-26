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
    private float attackSpeed = 2f;
    private float moveSpeed = 8f;

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
            else if ((Time.time - lastAttack) > attackSpeed) {
                Attack();
                lastAttack = Time.time;
            }
        }

        else if (Vector2.Equals(new Vector2(transform.position.x, transform.position.y), newLocation)) {
            moving = false;
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, newLocation, moveSpeed * Time.deltaTime);
            // animator.SetFloat("LastHorizontal", h);
            // animator.SetFloat("LastVertical", v);
        }

        
    }

    void Move() {
        moving = true;
        lastMove = Time.time;
        newLocation = new Vector2(Random.Range(-moveRange, moveRange) + controller.position.x, Random.Range(-moveRange, moveRange) + controller.position.y);
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

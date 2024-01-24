using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalController : MonoBehaviour
{

    [SerializeField] private GameObject waterBoltPrefab;
    [SerializeField] private Transform releasePoint;

    [SerializeField] private Transform test;


    void Start() 
    {
        ThrowBolt(test);
    }

    void Update()
    {
        if (Pause.isPaused) {
            return;
        }
    }

    public void ThrowBolt(Transform towards) 
    {
        Vector2 aimDirection = new Vector2(towards.position.x, towards.position.y) - new Vector2(transform.position.x, transform.position.y);

        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        releasePoint.rotation = Quaternion.Euler(0f, 0f, aimAngle);
        
        Instantiate(waterBoltPrefab, releasePoint.position, releasePoint.rotation);
    }
}

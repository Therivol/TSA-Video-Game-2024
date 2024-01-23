using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicWeapon : MonoBehaviour
{

    private Animator animator;

    [SerializeField] private GameObject garlicPrefab;
    [SerializeField] private Transform releasePoint;
    [SerializeField] private Animator playerAnimator;


    private float lastTimeThrown;


    void Start() 
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStats.playerStats.currentAmmo += PlayerStats.playerStats.ammoRegen * Time.deltaTime;
        if (PlayerStats.playerStats.currentAmmo > PlayerStats.playerStats.maxAmmo) {
            PlayerStats.playerStats.currentAmmo = PlayerStats.playerStats.maxAmmo;
        }
        
        if (Input.GetMouseButton(0)) {
            ThrowGarlic();
        }
    }

    private void ThrowGarlic() {

    if (PlayerStats.playerStats.currentAmmo >= 1f && (Time.time - lastTimeThrown) > PlayerStats.playerStats.throwingSpeed)
        {
            PlayerStats.playerStats.currentAmmo--;
            lastTimeThrown = Time.time;

            animator.Play("Player_Throw", 0, 0f);
            
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 aimDirection = mousePos - new Vector2(transform.position.x, transform.position.y);

            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            releasePoint.rotation = Quaternion.Euler(0f, 0f, aimAngle);
            
            Instantiate(garlicPrefab, releasePoint.position, releasePoint.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWeapon : MonoBehaviour
{
    [SerializeField] private GameObject lightBeam;
    [SerializeField] private Transform origin;


    // Start is called before the first frame update
    void Start()
    {
        DisableLight();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.isPaused) {
            return;
        }

        PlayerStats.playerStats.currentMana += PlayerStats.playerStats.mps * Time.deltaTime;
        if (PlayerStats.playerStats.currentMana > PlayerStats.playerStats.maxMana) {
            PlayerStats.playerStats.currentMana = PlayerStats.playerStats.maxMana;
        }

        if (Input.GetMouseButtonDown(1)) {
            if (PlayerStats.playerStats.currentMana != 0) {
                EnableLight();
            }
        }

        if (Input.GetMouseButton(1)) {
            UpdateLight();
        }

        if (Input.GetMouseButtonUp(1)) {
            DisableLight();
        }
    }

    void EnableLight() 
    {
        PlayerStats.playerStats.canMove = false;
        lightBeam.SetActive(true);
    }

    void UpdateLight() 
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePos - new Vector2(origin.position.x, origin.position.y);

        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90f;
        lightBeam.transform.rotation = Quaternion.Euler(0f, 0f, aimAngle);
        
        PlayerStats.playerStats.currentMana -= PlayerStats.playerStats.manaUseRate * Time.deltaTime;
        if (PlayerStats.playerStats.currentMana <= 0) {
            PlayerStats.playerStats.currentMana = 0;
            DisableLight();
        }
    }

    void DisableLight() 
    {
        PlayerStats.playerStats.canMove = true;
        lightBeam.SetActive(false);

    }
}

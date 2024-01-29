using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    public GameObject player;

    public bool canMove = true;

    public float currentMana = 100f;
    public float maxMana = 100f;
    public float mps = 10f;
    public float manaUseRate = 50f;
    public float lightDPS = 200f;

    public float currentAmmo = 10f;
    public float maxAmmo = 10f;
    public float baseThrowingSpeed = 3f;
    public float throwingSpeed = 3f;
    public float ammoRegen = 0.5f;
    public float garlicDamage = 75f;

    public float moveSpeed = 6f;

    public int speedCounter;
    public int capacityCounter;
    public int powerCounter;

    public float boltDamage = 100f;
    public float boltFreq = 0.4f;
    public float boltSpeed = 75f;

    void Awake() {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

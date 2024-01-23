using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    public GameObject player;

    public float currentMana = 100f;
    public float maxMana = 100f;
    public float mps = 10f;
    public float manaUseRate = 50f;
    public float lightDPS = 200f;

    public float currentAmmo = 10f;
    public float maxAmmo = 10f;
    public float throwingSpeed = 0.25f;
    public float ammoRegen = 0.5f;

    void Awake() {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed: MonoBehaviour
{
    [SerializeField] private AudioClip powerUpSound;

    void OnTriggerEnter2D() {
        PlayerStats.playerStats.speedCounter++;

        PlayerStats.playerStats.throwingSpeed += 0.05f;
        PlayerStats.playerStats.ammoRegen += 0.1f;
        PlayerStats.playerStats.mps += 1f;
        PlayerStats.playerStats.moveSpeed += 0.1f;
        PlayerStats.playerStats.boltFreq += 0.05f;
        PlayerStats.playerStats.boltSpeed += 0.5f;
        
        SoundFXManager.instance.PlaySoundFXClip(powerUpSound, transform, 0.6f);
        Destroy(gameObject);
    }
}

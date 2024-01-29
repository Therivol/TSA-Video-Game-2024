using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCapacity: MonoBehaviour
{
    [SerializeField] private AudioClip powerUpSound;

    void OnTriggerEnter2D() {
        PlayerStats.playerStats.capacityCounter++;

        PlayerStats.playerStats.maxMana += 10f;
        PlayerStats.playerStats.maxAmmo += 1f;
        SoundFXManager.instance.PlaySoundFXClip(powerUpSound, transform, 0.6f);
        
        Destroy(gameObject);
    }
}

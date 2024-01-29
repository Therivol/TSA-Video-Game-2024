using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpStrength: MonoBehaviour
{

    [SerializeField] private AudioClip powerUpSound;

    void OnTriggerEnter2D() {
        PlayerStats.playerStats.powerCounter++;

        PlayerStats.playerStats.lightDPS += 25f;
        PlayerStats.playerStats.garlicDamage += 5f;
        PlayerStats.playerStats.boltDamage += 5f;

        SoundFXManager.instance.PlaySoundFXClip(powerUpSound, transform, 0.6f);
        Destroy(gameObject);
    }
}

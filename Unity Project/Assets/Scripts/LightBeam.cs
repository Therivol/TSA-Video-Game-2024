using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D other) 
    {
        other.gameObject.GetComponent<VampireController>().TakeDamage(PlayerStats.playerStats.lightDPS * Time.deltaTime);
    }
}

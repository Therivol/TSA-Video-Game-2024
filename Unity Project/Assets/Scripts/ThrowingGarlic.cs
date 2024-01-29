using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingGarlic : MonoBehaviour
{

    public float speed = 20f;
    public float lifeTime = 3f;
    [SerializeField] private float garlicDamage;

    private Rigidbody2D rb;

    [SerializeField] private GameObject impactEffect;

    [SerializeField] private AudioClip hitVampireClip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
        garlicDamage = PlayerStats.playerStats.garlicDamage;
    }

    void FixedUpdate() {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        switch(other.gameObject.tag)
        {
            case "Wall":
            Impact();
            break;

            case "Enemy":
            other.gameObject.GetComponent<VampireController>().TakeDamage(garlicDamage);
            Impact();
            break;
        }
    }

    void Impact()
    {
        SoundFXManager.instance.PlaySoundFXClip(hitVampireClip, transform, 1f);
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

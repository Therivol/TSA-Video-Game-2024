using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GateController : MonoBehaviour
{

    [SerializeField] private AudioClip throughGate;
    private UnityEvent vampEnter = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        vampEnter.AddListener(GameManager.gameManager.VampEnter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        SoundFXManager.instance.PlaySoundFXClip(throughGate, transform, 0.2f);
        Destroy(other.gameObject);
        vampEnter.Invoke();
    }
}

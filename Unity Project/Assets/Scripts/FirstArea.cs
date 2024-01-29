using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.GetComponent<VampireController>().SetTarget(GameManager.gameManager.vampTarget);

    }
}

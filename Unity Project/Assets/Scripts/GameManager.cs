using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] public Transform vampTarget;

    private int vampsEntered;
    private int maxVamps = 3;
    public float vampResetFreq = 30f;
    public float vampResetTime;

    void Awake() {
        if (gameManager != null)
        {
            Destroy(gameManager);
        }
        else
        {
            gameManager = this;
        }
    }

    void Update()
    {
        if (vampsEntered >= 1) {
            vampResetTime += Time.deltaTime;

            if (vampResetTime >= vampResetFreq) {
                vampsEntered--;
            }
        }
    }

    public void vampEnter() {
        vampsEntered++;
        vampResetTime = 0f;
        if (vampsEntered == maxVamps) {
            Lose();
        }
    }

    void Lose() {
        SceneManager.LoadScene(2);
    }

    public void Menu() {
        SceneManager.LoadScene(1);
    }
}

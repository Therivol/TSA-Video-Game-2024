using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LossController : MonoBehaviour
{ 

    [SerializeField] private TMP_Text waveText;

    void Start() {
        waveText.text = "Wave " + HighScore.instance.lastScore;
    }

    public void Restart() {
        SceneManager.LoadScene(1);
    }

    public void Menu() {
        SceneManager.LoadScene(0);
    }
}

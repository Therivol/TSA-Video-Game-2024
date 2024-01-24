using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }

    public void PauseGame() {
        isPaused = true;
        pauseMenu.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        isPaused = false;
        pauseMenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }
}

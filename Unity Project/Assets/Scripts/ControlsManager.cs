using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsManager : MonoBehaviour
{
    public void Ret() {
        SceneManager.LoadScene(0);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Ret();
        }
    }
}

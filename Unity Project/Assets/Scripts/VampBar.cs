using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VampBar : MonoBehaviour
{
    int currentVamps = 0;

    [SerializeField] private Image[] vampContainers;
    [SerializeField] private Sprite containerEmpty;
    [SerializeField] private Sprite containerFull;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        int entered = GameManager.gameManager.vampsEntered;
        if (currentVamps != entered) {
            currentVamps = entered;

            Reset();

            for (int i = 0; i < entered; i++) {
                vampContainers[i].sprite = containerFull;
            }
        }
    }

    void Reset() {
        foreach (Image img in vampContainers) {
            img.sprite = containerEmpty;
        }
    }
}

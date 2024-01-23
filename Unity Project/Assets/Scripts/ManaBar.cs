using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{

    private Image barImage;

    void Awake()
    {
        barImage = transform.Find("ManaBar").GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barImage.fillAmount = PlayerStats.playerStats.currentMana / PlayerStats.playerStats.maxMana;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarlicBar : MonoBehaviour
{
    private Image barImage;

    void Awake()
    {
        barImage = transform.Find("GarlicBar").GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barImage.fillAmount = PlayerStats.playerStats.currentAmmo / PlayerStats.playerStats.maxAmmo;
    }
}

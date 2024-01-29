using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Slider slider = gameObject.GetComponent<Slider>();
        slider.value = SoundMixerManager.instance.masterVol;
        slider.onValueChanged.AddListener(SoundMixerManager.instance.SetMasterVolume);
    }
}

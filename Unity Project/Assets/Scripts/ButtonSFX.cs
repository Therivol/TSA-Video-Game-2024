using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSFX : MonoBehaviour, IPointerEnterHandler
{
    void Start() {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    void OnClick() {
        SoundFXManager.instance.PlayButtonSFX();
    }

    public void OnPointerEnter(PointerEventData data) {
        SoundFXManager.instance.PlayButtonSFX();
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToggleEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem clickParticles;
    [SerializeField] private Toggle toggle;

    private bool oldState;

    public void Start() {
        oldState = toggle.isOn;
    }

    public void OnValueChanged(bool newState) {
        if (newState == true && oldState == false) PlayButtonEffects();
        oldState = newState;
    }

    public void PlayButtonEffects() {
        clickParticles.Play();
    }
}

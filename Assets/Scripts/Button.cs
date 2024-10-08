using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private ParticleSystem clickParticles;
    [SerializeField] private Animator animator;

    public void OnClick() {
        PlayButtonEffects();
    }

    public void OnValueChanged(bool newState) {
        if (newState == true) PlayButtonEffects();
    }

    public void PlayButtonEffects() {
        clickParticles.Play();
    }
}

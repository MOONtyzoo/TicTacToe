using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] private ParticleSystem clickParticles;

    public void OnClick() {
        PlayButtonEffects();
    }

    public void PlayButtonEffects() {
        clickParticles.Play();
    }
}

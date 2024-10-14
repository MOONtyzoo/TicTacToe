using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem leftConfettiParticles;
    [SerializeField] private ParticleSystem rightConfettiParticles;

    public void shootConfetti() {
        leftConfettiParticles.Play();
        rightConfettiParticles.Play();
    } 
}

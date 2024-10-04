using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip resetClip;
    public AudioClip gameModeClip;

    public AudioClip gameOverClip;
    public AudioClip gameTiedClip;
    public AudioClip gameWonClip;

    public List<AudioClip> markerPlacedClips;

    private List<int> markerSoundQueue;

    public void Start() {
        ResetMarkerSoundQueue();
    }

    public void PlayResetSound() {
        audioSource.clip = resetClip;
        audioSource.Play();
    }

    public void PlayGameModeSound() {
        audioSource.clip = gameModeClip;
        audioSource.Play();
    }

    public void PlayGameOverSound() {
        audioSource.clip = gameOverClip;
        audioSource.Play();
    }

    public void PlayGameTiedSound() {
        audioSource.clip = gameTiedClip;
        audioSource.Play();
    }

    public void PlayGameWonSound() {
        audioSource.clip = gameWonClip;
        audioSource.Play();
    }

    public void PlayMarkerSound() {
        if (markerSoundQueue.Count == 0) ResetMarkerSoundQueue();

        int index = markerSoundQueue[0];
        markerSoundQueue.RemoveAt(0);
        
        audioSource.clip = markerPlacedClips[index];
        audioSource.Play();
    }

    private void ResetMarkerSoundQueue() {
        List<int> numberPool = new List<int>();
        for (int i = 0; i < markerPlacedClips.Count; i++) {
            numberPool.Add(i);
        }

        markerSoundQueue = new List<int>();
        for (int i = 0; i < markerPlacedClips.Count; i++) {
            int randomIndex = Random.Range(0, numberPool.Count);
            markerSoundQueue.Add(numberPool[randomIndex]);
            numberPool.RemoveAt(randomIndex);
        }
    }
}

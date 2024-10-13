using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedLine : MonoBehaviour
{
    [SerializeField] private LineRenderer animatedLine;

    public void Hide() {
        animatedLine.enabled = false;
    }

    public void Show() {
        animatedLine.enabled = true;
    }

    public void SetColor(Color newColor) {
        animatedLine.startColor = newColor;
        animatedLine.endColor = newColor;
    }
}

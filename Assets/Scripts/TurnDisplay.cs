using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnDisplay : MonoBehaviour
{
    public Image markerImage;
    public Sprite PantherSprite;
    public Sprite PawSprite;

    public void Set(MarkerType marker) {
        if (marker == MarkerType.Panther) {
            markerImage.sprite = PantherSprite;
        } else if (marker == MarkerType.Paw) {
            markerImage.sprite = PawSprite;
        }
    }
}

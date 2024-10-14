using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerDisplay : MonoBehaviour
{
    public Image markerImage;
    public Sprite EmptySprite;
    public Sprite PantherSprite;
    public Sprite PawSprite;
    public Sprite TieSprite;

    public void Reset() {
        markerImage.sprite = EmptySprite;
    }

    public void Set(MarkerType marker) {
        if (marker == MarkerType.None) {
            markerImage.sprite = EmptySprite;
        } else if (marker == MarkerType.Panther) {
            markerImage.sprite = PantherSprite;
        } else if (marker == MarkerType.Paw) {
            markerImage.sprite = PawSprite;
        } else if (marker == MarkerType.Tie) {
            markerImage.sprite = TieSprite;
        }
    }
}

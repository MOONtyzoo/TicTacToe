using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Slots slots;
    public Image markerImage;
    public int slotNumber = 0;

    private bool isMarked = false;

    public void OnClick() {
        if (IsEmpty())
           slots.OnSlotClicked(this);
    }

    public bool IsEmpty() {
        return !isMarked;
    }

    public bool IsMarked() {
        return isMarked;
    }

    public void Mark(Sprite markerSprite) {
        isMarked = true;
        SetTexture(markerSprite);
    }

    public void ResetMark(Sprite sprite) {
        isMarked = false;
        SetTexture(sprite);
    }

    public void SetTexture(Sprite sprite) {
        markerImage.sprite = sprite;
    }
}

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
    [SerializeField] private Animator animator;

    private bool isMarked = false;
    private bool isPreviewEnabeled = false;

    private float previewAnimTime = 0;
    void Update() {
        if (!isMarked && isPreviewEnabeled) {
            float alpha = 0.70f + 0.08f*(float)Math.Sin(previewAnimTime*3.0);
            markerImage.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        } else {
            markerImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        previewAnimTime += Time.deltaTime;
    }

    public void OnClick() {
        if (IsEmpty())
           slots.OnSlotClicked(this);
    }

    public void OnMouseEnter()
    {
        slots.OnSlotMouseEntered(this);
    }

    public void OnMouseExit()
    {
        slots.OnSlotMouseExited(this);
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
        animator.Play("PlaceMarker", 0, 0.0f);
    }

    public void ResetSlot(Sprite sprite) {
        isMarked = false;
        isPreviewEnabeled = false;
        SetTexture(sprite);
    }

    public void EnablePreview(Sprite markerSprite) {
        isPreviewEnabeled = true;
        previewAnimTime = 0;
        SetTexture(markerSprite);
    }

    public void DisablePreview(Sprite markerSprite) {
        isPreviewEnabeled = false;
        SetTexture(markerSprite);
    }

    public void SetTexture(Sprite sprite) {
        markerImage.sprite = sprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Slots : MonoBehaviour
{
    public TicTacToeGame ticTacToeGame;
    public List<Slot> slotsList;
    public Sprite pantherSprite;
    public Sprite pawSprite;
    public Sprite blankSprite;

    private List<MarkerType> slotOccupants;

    public void OnSlotClicked(Slot slot) {
        ticTacToeGame.OnSlotClicked(slot);
    }

    public void OnSlotMouseEntered(Slot slot) {
        ticTacToeGame.OnSlotMouseEntered(slot);
    }

    public void OnSlotMouseExited(Slot slot) {
        ticTacToeGame.OnSlotMouseExited(slot);
    }

    public void UpdateSlot(Slot slot, MarkerType markerType) {
        MarkSlot(slot, markerType);
        SetSlotOccupant(slot, markerType);
    }

    public void PreviewSlot(Slot slot, MarkerType markerType) {
        slot.EnablePreview(GetMarkerSprite(markerType));
    }

    public void UnPreviewSlot(Slot slot) {
        slot.DisablePreview(blankSprite);
    }

    public void SetSlotOccupant(Slot slot, MarkerType markerType) {
        int slotIndex = slot.slotNumber - 1;
        slotOccupants[slotIndex] = markerType;
    }

    private void MarkSlot(Slot slot, MarkerType markerType) {
        slot.Mark(GetMarkerSprite(markerType));
    }

    private Sprite GetMarkerSprite(MarkerType markerType) {
        if (markerType == MarkerType.Panther)
            return pantherSprite;
        else if (markerType == MarkerType.Paw)
            return pawSprite;
        else if (markerType == MarkerType.None)
            return blankSprite;
        return blankSprite;
    }

    public void Reset() {
        ResetSlotOccupants();
        ResetSlotImages();
    }

    public List<MarkerType> GetSlotOccupants() {
        return slotOccupants;
    }

    public Slot GetRandomFreeSlot() {
        List<Slot> emptySlots = slotsList.FindAll(delegate(Slot slot) {
            return slot.IsEmpty();
        });
        
        int randomIndex = Random.Range(0, emptySlots.Count);
        return emptySlots[randomIndex];
    }

    private void ResetSlotImages() {
        foreach (Slot slot in slotsList) {
            slot.ResetSlot(blankSprite);
        }
    }

    private void ResetSlotOccupants() {
        slotOccupants = new List<MarkerType>();
        for (int i = 0; i < 9; i++) {
            slotOccupants.Add(MarkerType.None);
        }
    }
}

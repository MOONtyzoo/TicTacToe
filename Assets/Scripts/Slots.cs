using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void UpdateSlot(Slot slot, MarkerType markerType) {
        SetSlotImage(slot, markerType);
        SetSlotOccupant(slot, markerType);
    }

    public void SetSlotOccupant(Slot slot, MarkerType markerType) {
        int slotIndex = slot.slotNumber - 1;
        slotOccupants[slotIndex] = markerType;
    }

    private void SetSlotImage(Slot slot, MarkerType markerType) {
        if (markerType == MarkerType.Panther)
            slot.Mark(pantherSprite);
        else if (markerType == MarkerType.Paw)
            slot.Mark(pawSprite);
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
            slot.ResetMark(blankSprite);
        }
    }

    private void ResetSlotOccupants() {
        slotOccupants = new List<MarkerType>();
        for (int i = 0; i < 9; i++) {
            slotOccupants.Add(MarkerType.None);
        }
    }
}

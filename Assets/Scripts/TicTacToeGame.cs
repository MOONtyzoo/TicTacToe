using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGame : MonoBehaviour
{
    public Slots slots;
    public TurnDisplay turnDisplay;
    public WinnerDisplay winnerDisplay;
    public GameMode gameMode;
    public Sounds sounds;

    private MarkerType currentMarkerType;
    private MarkerType firstPlayerMarkerType;
    private int numberOfTurnsPlayed;

    private MarkerType winner = MarkerType.None;

    void Start()
    {
        Reset();
    }

    public void OnSlotClicked(Slot slot) {
        if (!IsGameOver() && IsHumanTurn()) {
            PlaceMarkerInSlot(slot);
        }
    }

    public void OnResetButtonClicked() {
        Reset();
        sounds.PlayResetSound();
    }

    public void Reset() {
        ResetSlots();
        ResetPlayers();
        turnDisplay.Set(currentMarkerType);
        winnerDisplay.Reset();
        winner = MarkerType.None;
        numberOfTurnsPlayed = 0;
    }

    private void ResetSlots() {
        slots.Reset();
    }

    private void ResetPlayers() {
        RandomizeCurrentMarker();
        firstPlayerMarkerType = currentMarkerType;
    }

    public void PlaceMarkerInSlot(Slot slot) {
        UpdateSlotImage(slot);
        sounds.PlayMarkerSound();
        EndTurn();
    }

    public MarkerType GetCurrentMarkerType() {
        return currentMarkerType;
    }

    private void EndTurn() {
        CheckForWinner();
        if (IsGameOver()) {
            OnGameWon();
            return;
        }

        ChangePlayer();
        turnDisplay.Set(currentMarkerType);
        
        if (IsComputerTurn()) {
            PlayComputerTurn();
        }
    }

    private void CheckForWinner() {
        numberOfTurnsPlayed++;

        winner = TicTacToeResolver.GetWinner(slots.GetSlotOccupants());
        if (winner == MarkerType.None && numberOfTurnsPlayed >= 9)
            winner = MarkerType.Tie;
    }

    private void OnGameWon() {
        winnerDisplay.Set(winner);
        if (winner == MarkerType.Tie) sounds.PlayGameTiedSound();
        else sounds.PlayGameOverSound();
    }

    private bool IsGameOver() {
        return (winner != MarkerType.None);
    }

    private void ChangePlayer() {
        if (currentMarkerType == MarkerType.Paw)
            currentMarkerType = MarkerType.Panther;
        else
            currentMarkerType = MarkerType.Paw;
    }

    private bool IsHumanTurn() {
        bool isComputerMode = gameMode.GetOpponentType() != OpponentType.Human;
        bool isTwoPlayerMode = gameMode.GetOpponentType() == OpponentType.Human;
        bool isHumanTurn = currentMarkerType == firstPlayerMarkerType;
        return isTwoPlayerMode || (isComputerMode && isHumanTurn);
    }

    private bool IsComputerTurn() {
        bool isComputerMode = gameMode.GetOpponentType() != OpponentType.Human;
        bool isComputerTurn = currentMarkerType != firstPlayerMarkerType;
        return isComputerMode && isComputerTurn;
    }

    private void PlayComputerTurn() {
        StartCoroutine(ComputerPlayer.PlayComputerTurn(this));
    }

    private void ChangeOpponent() {
        Reset();
    }

    private void UpdateSlotImage(Slot slot) {
        slots.UpdateSlot(slot, currentMarkerType);
    }

    private void RandomizeCurrentMarker() {
        int randomNumber = Random.Range(1, 3);
        currentMarkerType = (randomNumber == 1) ? MarkerType.Panther : MarkerType.Paw;
    }
}

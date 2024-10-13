using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGame : MonoBehaviour
{
    [Header("Game Components")]
    [SerializeField] public Slots slots;
    [SerializeField] private TurnDisplay turnDisplay;
    [SerializeField] private WinnerDisplay winnerDisplay;
    [SerializeField] public GameMode gameMode;

    [Header("Effects Components")]
    [SerializeField] private Sounds sounds;
    [SerializeField] private ParticleManager particleManager;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimatedLine animatedBorderLine;
    [SerializeField] private BoardObscurer boardObscurer;

    [Header("Colors")]
    [SerializeField] private Color redTurnColor;
    [SerializeField] private Color blueTurnColor;

    private MarkerType currentMarkerType;
    private MarkerType firstPlayerMarkerType;
    private int numberOfTurnsPlayed;

    private MarkerType winner = MarkerType.None;
    private Coroutine opponentTurnCoroutine;

    void Start()
    {
        Reset();
    }

    public void OnSlotClicked(Slot slot) {
        if (!IsGameOver() && IsHumanTurn()) {
            PlaceMarkerInSlot(slot);
        }
    }

    public void OnSlotMouseEntered(Slot slot) {
        if (!slot.IsMarked() && IsHumanTurn())
            slots.PreviewSlot(slot, currentMarkerType);
    }

    public void OnSlotMouseExited(Slot slot) {
        if (!slot.IsMarked())
            slots.UnPreviewSlot(slot);
    }

    public void OnResetButtonClicked() {
        Reset();
        sounds.PlayResetSound();
        animator.Play("ResetBoard", 0, 0.0f );
    }

    public void Reset() {
        ResetSlots();
        ResetPlayers();
        turnDisplay.Set(currentMarkerType);
        UpdateAnimatedBorderLine();
        boardObscurer.Deactivate();
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
        if (opponentTurnCoroutine != null) StopCoroutine(opponentTurnCoroutine);
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
            OnGameOver();
            return;
        }

        ChangePlayer();
        turnDisplay.Set(currentMarkerType);
        UpdateAnimatedBorderLine();
        
        if (IsComputerTurn()) {
            boardObscurer.Activate();
            PlayComputerTurn();
        } else {
            boardObscurer.Deactivate();
        }
    }

    private void CheckForWinner() {
        numberOfTurnsPlayed++;

        winner = TicTacToeResolver.GetWinner(slots.GetSlotOccupants());
        if (winner == MarkerType.None && numberOfTurnsPlayed >= 9)
            winner = MarkerType.Tie;
    }

    private bool IsGameOver() {
        return (winner != MarkerType.None);
    }

    private void OnGameOver() {
        winnerDisplay.Set(winner);

        // Check if we should play "tie" effects
        if (winner == MarkerType.Tie) {
            OnGameTied();
            return;
        }

        // If both players are humans, we play the win effect no matter who wins
        if (gameMode.GetOpponentType() == OpponentType.Human) {
            OnGameWon();
            return;
        }

        // If the opponenet is a robot, then we can actually lose
        if (winner == firstPlayerMarkerType) {
            OnGameWon();
        } else {
            OnGameLost();
        }
    }

    private void OnGameWon() {
        sounds.PlayGameWonSound();
        particleManager.shootConfetti();
    }

    private void OnGameTied() {
        sounds.PlayGameTiedSound();
    }

    private void OnGameLost() {
        sounds.PlayGameOverSound();
    }

    private void ChangePlayer() {
        if (currentMarkerType == MarkerType.Paw)
            currentMarkerType = MarkerType.Panther;
        else
            currentMarkerType = MarkerType.Paw;
    }

    private void UpdateAnimatedBorderLine() {
        if (currentMarkerType == MarkerType.Panther)
            animatedBorderLine.SetColor(redTurnColor);
        else
            animatedBorderLine.SetColor(blueTurnColor);
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
       opponentTurnCoroutine = StartCoroutine(ComputerPlayer.PlayComputerTurn(this));
    }

    private void UpdateSlotImage(Slot slot) {
        slots.UpdateSlot(slot, currentMarkerType);
    }

    private void RandomizeCurrentMarker() {
        int randomNumber = Random.Range(1, 3);
        currentMarkerType = (randomNumber == 1) ? MarkerType.Panther : MarkerType.Paw;
    }
}

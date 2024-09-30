using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComputerPlayer
{
    public static IEnumerator PlayComputerTurn(TicTacToeGame game) {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.2f));

        if (game.gameMode.GetOpponentType() == OpponentType.EasyComputer) {
            PlayEasyComputerMove(game);
        } else if (game.gameMode.GetOpponentType() == OpponentType.BrutalComputer) {
            PlayBrutalComputerMove(game);
        }
    }

    private static void PlayEasyComputerMove(TicTacToeGame game) {
        Slot chosenSlot = game.slots.GetRandomFreeSlot();
        game.PlaceMarkerInSlot(chosenSlot);
    }

    private static void PlayBrutalComputerMove(TicTacToeGame game) {
        Slot chosenSlot;

        int winningSlotIndex = TicTacToeResolver.GetWinningMove(game.slots.GetSlotOccupants(), game.GetCurrentMarkerType());
        bool canWinGame = winningSlotIndex != -1;

        MarkerType opponentMarkerType = (game.GetCurrentMarkerType() == MarkerType.Panther) ? MarkerType.Paw : MarkerType.Panther;
        int blockingSlotIndex = TicTacToeResolver.GetWinningMove(game.slots.GetSlotOccupants(), opponentMarkerType);
        bool canBlockPlayer = blockingSlotIndex != -1;

        if (canWinGame) {
            chosenSlot = game.slots.slotsList[winningSlotIndex];
        } else if (canBlockPlayer) {
            chosenSlot = game.slots.slotsList[blockingSlotIndex];
        } else {
            chosenSlot = game.slots.GetRandomFreeSlot();
        }

        game.PlaceMarkerInSlot(chosenSlot);
    }
}

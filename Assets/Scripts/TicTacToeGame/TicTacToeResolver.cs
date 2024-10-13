using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class TicTacToeResolver
{
    private static readonly int[][] winningConfigurations = {
        // Three in a row
        new int[] {1, 2, 3},
        new int[] {4, 5, 6},
        new int[] {7, 8, 9},

        // Three in a column
        new int[] {1, 4, 7},
        new int[] {2, 5, 8},
        new int[] {3, 6, 9},

        // Three in a diagonal
        new int[] {1, 5, 9},
        new int[] {3, 5, 7}
    };

    // Returns the index of the first winning move for the currentMarker
    public static int GetWinningMove(List<MarkerType> slotOccupants, MarkerType currentMarker) {
        int winningSlotIndex = -1;
        for (int i = 0; i < slotOccupants.Count; i++) {
            if (slotOccupants[i] == MarkerType.None) {
                List<MarkerType> predictedSlotOccupants = new List<MarkerType>(slotOccupants);
                predictedSlotOccupants[i] = currentMarker;
                MarkerType winner = GetWinner(predictedSlotOccupants);
                if (winner == currentMarker) {
                    winningSlotIndex = i;
                    return winningSlotIndex;
                }
            }
        }
        return winningSlotIndex;
    }

    public static int GetBlockingMove(List<MarkerType> slotOccupants, MarkerType currentMarker) {
        return -1;
    }

    public static MarkerType GetWinner(List<MarkerType> slotOccupants) {
        foreach (int[] winningConfiguration in winningConfigurations) {
            if (IsConfigurationWon(winningConfiguration, slotOccupants)) {
                MarkerType winningMarker = slotOccupants[winningConfiguration[0]-1];
                return winningMarker;
            }
        }

        if (IsGameTied(slotOccupants)) {
            return MarkerType.Tie;
        }

        return MarkerType.None;
    }

    public static bool IsGameTied(List<MarkerType> slotOccupants) {
        foreach (MarkerType slot in slotOccupants)
            if (slot == MarkerType.None) return false;
        
        return true;
    }

    private static bool IsConfigurationWon(int[] winningConfiguration, List<MarkerType> slotOccupants) {
        MarkerType slotA = slotOccupants[winningConfiguration[0]-1];
        MarkerType slotB = slotOccupants[winningConfiguration[1]-1];
        MarkerType slotC = slotOccupants[winningConfiguration[2]-1];

        bool slotsMatch = slotA == slotB && slotB == slotC;
        bool slotsNotEmpty = slotA != MarkerType.None;

        return slotsMatch && slotsNotEmpty;
    }
}

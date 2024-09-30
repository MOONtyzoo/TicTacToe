using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public TicTacToeGame ticTacToeGame;
    public Sounds sounds;
    private OpponentType currentOpponentType;

    void Start()
    {
        currentOpponentType = OpponentType.Human;
    }

    public void OnButtonPressed(int buttonNumber) {
        OpponentType opponentType = ButtonNumToOpponentType(buttonNumber);
        ChangeOpponentType(opponentType);
    }

    public OpponentType GetOpponentType() {
        return currentOpponentType;
    }

    private void ChangeOpponentType(OpponentType newOpponentType) {
        if (currentOpponentType != newOpponentType) {
            currentOpponentType = newOpponentType;
            sounds.PlayGameModeSound();
            ticTacToeGame.Reset();
        }
    }

    private OpponentType ButtonNumToOpponentType(int buttonNumber) {
        OpponentType opponentType = OpponentType.Human;
        switch(buttonNumber) {
            case 0: opponentType = OpponentType.EasyComputer; break;
            case 1: opponentType = OpponentType.Human; break;
            case 2: opponentType = OpponentType.BrutalComputer; break;
        }
        return opponentType;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIContoller {

    private readonly GameRenderer _gameRenderer;
    private readonly List<IAction> _actions;

    public AIContoller(GameRenderer gameRenderer) {
        _gameRenderer = gameRenderer;
        _actions = new List<IAction>();
        SetUpActions();
    }

    public void RunAI() {
        DecideActionAndRun(_actions);
    }

    private void DecideActionAndRun(List<IAction> actions) {
        float currentHighScore = 0;
        IAction actionToRun = null;

        foreach (var action in actions) {
            float currentActionScore = action.Score();
            if (currentHighScore >= currentActionScore) continue;

            currentHighScore = currentActionScore;
            actionToRun = action;
        }
        Debug.Log(currentHighScore);
        actionToRun?.Act();
    }
    
    private void SetUpActions() {
        //_actions.Add(new PlaceAtLowestIndex(_gameRenderer));
        //_actions.Add(new PlaceNearAllyPieces(_gameRenderer));
        //_actions.Add(new PlaceAtRandomIndex(_gameRenderer));
        //_actions.Add(new PlaceNearEnemyPieces(_gameRenderer));
        _actions.Add(new BlockOpponent(_gameRenderer));
        _actions.Add(new PlaceForWin(_gameRenderer));
        _actions.Add(new TestBucket(_gameRenderer));
    }
}

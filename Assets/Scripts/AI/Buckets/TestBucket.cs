using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBucket : IAction {

    private readonly GameRenderer _gameRenderer;
    private readonly GameState _gameState;
    
    private AnimationCurve _scoreCurve;
    
    private int _optimalXPosition;

    private List<IAction> _actions; 
    public TestBucket(GameRenderer gameRenderer) {
        _gameRenderer = gameRenderer;
        _gameState = _gameRenderer._gameState;
        _scoreCurve = _gameRenderer._scores[AIActions.TEST_BUCKET];
        SetupActions();
    }

    public void Act() {
        Debug.Log("TestBucket");
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
        Debug.Log("bucket high score " + currentHighScore);
        actionToRun?.Act();
    }

    private void SetupActions() {
        _actions = new List<IAction> {
            new PlaceNearAllyPieces(_gameRenderer),
            new PlaceNearEnemyPieces(_gameRenderer),
            new PlaceAtRandomIndex(_gameRenderer)
        };
    }
    
    public float Score() {
        return _scoreCurve.Evaluate(0.5f);
    }
    
}

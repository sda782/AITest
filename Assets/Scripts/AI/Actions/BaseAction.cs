using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAction {
    
    protected GameRenderer _gameRenderer;
    protected GameState _gameState;
    
    protected AnimationCurve _scoreCurve;
    
    protected int _optimalXPosition;

    protected void SetUpVariables(GameRenderer gameRenderer, AIActions actionType) {
        _gameRenderer = gameRenderer;
        _gameState = _gameRenderer._gameState;
        _scoreCurve = _gameRenderer._scores[actionType];
    }
}

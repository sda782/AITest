using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOpponent : IAction {
    
    private readonly GameRenderer _gameRenderer;
    private readonly GameState _gameState;

    private AnimationCurve _scoreCurve;
    
    private int _optimalXPosition;
    
    public BlockOpponent(GameRenderer gameRenderer) {
        _gameRenderer = gameRenderer;
        _gameState = _gameRenderer._gameState;
        _scoreCurve = _gameRenderer._scores[AIActions.BLOCK_OPPONENT];
    }

    public void Act() {
        Debug.Log("BlockOpponent");
        _gameRenderer.PlacePiece(_optimalXPosition, false);
    }

    public float Score() {
        
        bool block = false;
        
        for (int i = 0; i < _gameState.width; i++) {
            if (block) continue;
            if (_gameState.CheckFor2InRow(i, true)) {
                block = true;
                _optimalXPosition = i;
            }
        }

        return _scoreCurve.Evaluate(block ? 1 : 0);
        //return block ? 1 : 0;
    }
}

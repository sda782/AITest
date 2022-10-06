using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOpponent : BaseAction, IAction {

    public BlockOpponent(GameRenderer gameRenderer) {
        SetUpVariables(gameRenderer,AIActions.BLOCK_OPPONENT);
    }

    public void Act() {
        Debug.Log("BlockOpponent");
        _gameRenderer.PlacePiece(_optimalXPosition, false);
    }

    public float Score() {
        
        bool block = false;
        
        for (int i = 0; i < _gameState.width; i++) {
            if (block) continue;
            if (_gameState.CheckFor3InRow(i, true)) {
                block = true;
                _optimalXPosition = i;
            }
        }

        return _scoreCurve.Evaluate(block ? 1 : 0);
        //return block ? 1 : 0;
    }
}

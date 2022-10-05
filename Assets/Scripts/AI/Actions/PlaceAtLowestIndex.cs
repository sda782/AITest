using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAtLowestIndex : IAction {

    private readonly GameRenderer _gameRenderer;
    private readonly GameState _gameState;
    
    private AnimationCurve _scoreCurve;
    
    private int _optimalXPosition;

    public PlaceAtLowestIndex(GameRenderer gameRenderer) {
        _gameRenderer = gameRenderer;
        _gameState = _gameRenderer._gameState;
        _scoreCurve = _gameRenderer._scores[AIActions.PLACE_AT_LOWEST_INDEX];
    }
    
    public void Act() {
        Debug.Log("PlaceAtLowestIndex");
        _gameRenderer.PlacePiece(_optimalXPosition, false);
    }

    public float Score() {
        int y = _gameState.height;
        for (int i = 0; i < _gameState.width; i++) {
            int nY = _gameState.FindEmptyY(i);
            if (nY < y) {
                y = nY;
                _optimalXPosition = i;
            }
        }

        return _scoreCurve.Evaluate(_gameState.BoardFullness());
        //return (1 - _gameState.BoardFullness())*0.2f;
    }
}

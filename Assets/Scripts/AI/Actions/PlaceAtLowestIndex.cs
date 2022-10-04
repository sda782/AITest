using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAtLowestIndex : IAction {

    private readonly GameRenderer _gameRenderer;
    private readonly GameState _gameState;
    private int _optimalXPosition;

    public PlaceAtLowestIndex(GameRenderer gameState) {
        _gameRenderer = gameState;
        _gameState = _gameRenderer._gameState;
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

        return (1 - _gameState.BoardFullness())*0.2f;
    }
}

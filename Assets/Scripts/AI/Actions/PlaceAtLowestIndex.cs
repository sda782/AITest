using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAtLowestIndex : BaseAction, IAction {

    public PlaceAtLowestIndex(GameRenderer gameRenderer) {
        SetUpVariables(gameRenderer,AIActions.PLACE_AT_LOWEST_INDEX);
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

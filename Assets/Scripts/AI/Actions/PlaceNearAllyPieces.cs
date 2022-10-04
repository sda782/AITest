using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceNearAllyPieces : IAction {
    
    private readonly GameRenderer _gameRenderer;
    private readonly GameState _gameState;
    private int _optimalXPosition;

    public PlaceNearAllyPieces(GameRenderer gameRenderer) {
        _gameRenderer = gameRenderer;
        _gameState = _gameRenderer._gameState;
    }
    public void Act() {
        Debug.Log("PlaceNearAllyPieces");
        _gameRenderer.PlacePiece(_optimalXPosition, false);
    }

    public float Score() {
        float numberOfAllies = 0;
        _optimalXPosition = 0;
        for (int i = 0; i < _gameState.width; i++) {
            int allies = _gameState.GetNumberOfAdjacentAlly(i, _gameState.FindEmptyY(i), false);
            if (allies <= numberOfAllies) continue;
            numberOfAllies = allies;
            _optimalXPosition = i;
        }
        
        return Mathf.Clamp01(Mathf.Pow(numberOfAllies,0.35f)*0.5f);
    }
}

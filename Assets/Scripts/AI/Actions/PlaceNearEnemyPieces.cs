using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceNearEnemyPieces : IAction {
    
    private readonly GameRenderer _gameRenderer;
    private readonly GameState _gameState;
    private int _optimalXPosition;

    public PlaceNearEnemyPieces(GameRenderer gameRenderer) {
        _gameRenderer = gameRenderer;
        _gameState = _gameRenderer._gameState;
    }
    public void Act() {
        Debug.Log("PlaceNearEnemyPieces");
        _gameRenderer.PlacePiece(_optimalXPosition, false);
    }

    public float Score() {
        float numberOfEnemies = 0;
        _optimalXPosition = 0;
        for (int i = 0; i < _gameState.width; i++) {
            int enemies = _gameState.GetNumberOfAdjacentEnemies(i, _gameState.FindEmptyY(i), false);
            if (enemies <= numberOfEnemies) continue;
            numberOfEnemies = enemies;
            _optimalXPosition = i;
        }
        
        return Mathf.Clamp01(Mathf.Pow(numberOfEnemies,2)*0.02f);
    }
}


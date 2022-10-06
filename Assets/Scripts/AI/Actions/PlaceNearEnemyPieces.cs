using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceNearEnemyPieces : BaseAction, IAction {

    public PlaceNearEnemyPieces(GameRenderer gameRenderer) {
        SetUpVariables(gameRenderer,AIActions.PLACE_NEAR_ENEMY_PIECES);
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

        return _scoreCurve.Evaluate(numberOfEnemies);
        //return Mathf.Clamp01(Mathf.Pow(numberOfEnemies,2)*0.02f);
    }
}


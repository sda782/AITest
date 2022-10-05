using UnityEngine;

public class PlaceForWin : IAction {
    
    private readonly GameRenderer _gameRenderer;
    private readonly GameState _gameState;
    
    private AnimationCurve _scoreCurve;
    
    private int _optimalXPosition;
    
    public PlaceForWin(GameRenderer gameRenderer) {
        _gameRenderer = gameRenderer;
        _gameState = _gameRenderer._gameState;
        _scoreCurve = _gameRenderer._scores[AIActions.PLACE_FOR_WIN];
    }

    public void Act() {
        Debug.Log("PlaceForWin");
        _gameRenderer.PlacePiece(_optimalXPosition, false);
    }

    public float Score() {
        bool win = false;
        
        for (int i = 0; i < _gameState.width; i++) {
            if (win) continue;
            if (_gameState.CheckFor2InRow(i, false)) {
                win = true;
                _optimalXPosition = i;
            }
        }

        return _scoreCurve.Evaluate(win ? 1 : 0);
        //return win ? 1 : 0;
    }
}

using UnityEngine;

public class PlaceForWin : BaseAction, IAction {

    public PlaceForWin(GameRenderer gameRenderer) {
        SetUpVariables(gameRenderer,AIActions.PLACE_FOR_WIN);
    }

    public void Act() {
        Debug.Log("PlaceForWin");
        _gameRenderer.PlacePiece(_optimalXPosition, false);
    }

    public float Score() {
        bool win = false;
        
        for (int i = 0; i < _gameState.width; i++) {
            if (win) continue;
            if (_gameState.CheckFor3InRow(i, false)) {
                win = true;
                _optimalXPosition = i;
            }
        }

        return _scoreCurve.Evaluate(win ? 1 : 0);
        //return win ? 1 : 0;
    }
}

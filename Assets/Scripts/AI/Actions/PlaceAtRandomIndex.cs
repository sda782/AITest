using UnityEngine;

public class PlaceAtRandomIndex : BaseAction, IAction {

    public PlaceAtRandomIndex(GameRenderer gameRenderer) {
        SetUpVariables(gameRenderer,AIActions.PLACE_AT_RANDOM_INDEX);
    }
    public void Act() {
        Debug.Log("PlaceAtRandomIndex");
        _gameRenderer.PlacePiece(Random.Range(0,_gameState.width),false);
    }

    public float Score() {
        return _scoreCurve.Evaluate(_gameState.BoardFullness());
        //return (1 - _gameState.BoardFullness())*0.2f;
    }
}

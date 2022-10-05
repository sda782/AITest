using UnityEngine;

public class PlaceAtRandomIndex : IAction {
    
    private readonly GameRenderer _gameRenderer;
    private readonly GameState _gameState;
    
    private AnimationCurve _scoreCurve;

    public PlaceAtRandomIndex(GameRenderer gameRenderer) {
        _gameRenderer = gameRenderer;
        _gameState = _gameRenderer._gameState;
        _scoreCurve = _gameRenderer._scores[AIActions.PLACE_AT_RANDOM_INDEX];
    }
    public void Act() {
        Debug.Log("PlaceAtRandomIndex");
        _gameRenderer.PlacePiece(Random.Range(0,_gameState.width),false);
    }

    public float Score() {
        Debug.Log(_scoreCurve.Evaluate(_gameState.BoardFullness()));
        return _scoreCurve.Evaluate(_gameState.BoardFullness());
        //return (1 - _gameState.BoardFullness())*0.2f;
    }
}

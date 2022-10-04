using UnityEngine;

public class PlaceAtRandomIndex : IAction {
    
    private readonly GameRenderer _gameRenderer;
    private readonly GameState _gameState;

    public PlaceAtRandomIndex(GameRenderer gameRenderer) {
        _gameRenderer = gameRenderer;
        _gameState = _gameRenderer._gameState;
    }
    public void Act() {
        Debug.Log("PlaceAtRandomIndex");
        _gameRenderer.PlacePiece(Random.Range(0,_gameState.width),false);
    }

    public float Score() {
        return (1 - _gameState.BoardFullness())*0.2f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRenderer : MonoBehaviour {
    
    private GameState _gameState;
    [SerializeField] private GameObject _cell;
    private GameObject[,] _board;
    private bool _isPlayerTurn;
    
    private void Start() {
        _gameState = new GameState();
        _board = new GameObject[_gameState.width, _gameState.height];
        
        SpawnGrid();

        _isPlayerTurn = true;
    }

    private void SpawnGrid() {
        for (int x = 0; x < _gameState.width; x++) {
            for (int y = 0; y < _gameState.height; y++) {
                var cellGameObject = Instantiate(_cell, new Vector3(x, y, 0), transform.rotation);
                cellGameObject.transform.SetParent(transform);

                var cell = cellGameObject.GetComponent<Cell>();
                cell.cellClicked += OnClickCell;
                cell.x = x;
                cell.y = y;
                _board[x, y] = cellGameObject;
            }   
        }

        transform.position = new Vector2(0 - _gameState.width / 2, 0 - _gameState.height / 2);
    }

    private void EndTurn() {
        _isPlayerTurn = true;
        if (_gameState.CheckForWinCondition(1)) Debug.Log("You Won");
    }

    private void OnClickCell(Cell cell) {
        if (!_isPlayerTurn) return;
        if (!_gameState.CheckSpace(cell.x)) return;
        int y = _gameState.FindEmptyY(cell.x);
        Debug.Log($"x {cell.x} y {y}");
        _gameState.PlaceToken(cell.x,true);
        _board[cell.x, y].GetComponent<SpriteRenderer>().color = Color.cyan;
        _isPlayerTurn = false;
        
        EndTurn();
    }
}

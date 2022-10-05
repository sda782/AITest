using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRenderer : MonoBehaviour {
    
    [SerializeField] private GameObject _cell;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Text _gameOverText;
    
    public GameState _gameState;
    private GameObject[,] _board;
    private bool _isPlayerTurn;

    private AIContoller _aiContoller;
    [SerializeField] private ScoreIndex _scoreIndex;
    public Dictionary<AIActions, AnimationCurve> _scores;

    private void Start() {
        
        foreach (var score in _scoreIndex.scores) {
            _scores.Add(score.actionType, score.scoreCurve);
        }
        
        _gameState = new GameState();
        _board = new GameObject[_gameState.width, _gameState.height];
        _aiContoller = new AIContoller(this);

        
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
        if (_gameState.CheckForWinCondition(1)) {
            _gameOverText.text = "You Won!";
            GameOver();
        }
        else {
            _aiContoller.RunAI();
            
            if (_gameState.CheckForWinCondition(2)) {
                _gameOverText.text = "You Lost!";
                GameOver();
            }
        }
        _isPlayerTurn = true;
    }

    private void GameOver() {
        _gameOverPanel.SetActive(true);
    }

    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlacePiece(int x, bool isPlayer) {
        if (!_gameState.CheckSpace(x)) return;
        int nY = _gameState.FindEmptyY(x);
        _gameState.PlaceToken(x,isPlayer);
        _board[x, nY].GetComponent<SpriteRenderer>().color = isPlayer ? Color.cyan : Color.magenta;
    }

    private void OnClickCell(Cell cell) {
        if (!_isPlayerTurn) return;
        PlacePiece(cell.x, true);
        _isPlayerTurn = false;
        EndTurn();
    }
}

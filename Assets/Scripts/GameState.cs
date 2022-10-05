using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState {
    private int[,] board;
    public int width = 7;
    public int height = 6;

    public GameState() {
        board = new int[width, height];
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                board[x, y] = 0;
            }
        }
    }
    
    public void PlaceToken(int x, bool player) {
        if (!CheckSpace(x)) return;
        board[x, FindEmptyY(x)] = player ? 1 : 2;
    }
    
    public bool CheckSpace(int x) {
        if (x <= 0 && x >= width) return false;

        int y = FindEmptyY(x);
        if (y == -1) return false;
        if (board[x, y] != 0) return false;
        return true;
    }

    public int FindEmptyY(int x) {
        int emptyY = -1;
        for (int y = height-1; y >= 0; y--) {
            if (board[x, y] != 0) continue;
            emptyY = y;
        }

        return emptyY;
    }
    
    private bool IsWithinBounds(int x, int y) {
        return x < width && y < height && x >= 0 && y >= 0;
    }

    public int GetNumberOfAdjacentAlly(int x, int y, bool isPlayer) {
        int numberOfAllies = 0;
        for (int i = x-1; i <= x+1; i++) {
            for (int j = y-1; j <= y+1; j++) {
                if (i == x && j == y) continue;
                if (!IsWithinBounds(i,j)) continue;
                if (board[i,j] == (isPlayer ? 2 : 1)) continue;
                if (board[i,j] == (isPlayer ? 1 : 2)) numberOfAllies++;
            }   
        }
        return numberOfAllies;
    }

    public float BoardFullness() {
        float fullness = 0;

        foreach (var space in board) {
            if (space == 0) continue;
            fullness++;
        }
        
        return fullness/board.Length;
    }

    public bool CheckFor2InRow(int x, bool checkForPlayer) {
        int y = FindEmptyY(x);
        int playerInt = checkForPlayer ? 1 : 2;

        if (IsWithinBounds(x-1,y) && IsWithinBounds(x+1,y)) {
            if (board[x-1,y] == playerInt && board[x+1,y] == playerInt) {
                return true;
            }
        }

        if (IsWithinBounds(x - 1, y) && IsWithinBounds(x - 2, y)) {
            if (board[x - 1, y] == playerInt && board[x - 2, y] == playerInt) {
                return true;
            }
        }

        if (IsWithinBounds(x + 1, y) && IsWithinBounds(x + 2, y)) {
            if (board[x + 1, y] == playerInt && board[x + 2, y] == playerInt) {
                return true;
            }
        }
        
        if (IsWithinBounds(x, y-1) && IsWithinBounds(x, y-2)) {
            if (board[x, y-1] == playerInt && board[x, y-2] == playerInt) {
                return true;
            }
        }

        return false;
    }

    public bool CheckForWinCondition(int player) {
        for (int j = 0; j<height-3 ; j++ ){
            for (int i = 0; i<width; i++){
                if (board[i,j] == player && board[i,j+1] == player && board[i,j+2] == player && board[i,j+3] == player){
                    return true;
                }           
            }
        }
        // verticalCheck
        for (int i = 0; i<width-3 ; i++ ){
            for (int j = 0; j<height; j++){
                if (board[i,j] == player && board[i+1,j] == player && board[i+2,j] == player && board[i+3,j] == player){
                    return true;
                }           
            }
        }
        // ascendingDiagonalCheck 
        for (int i=3; i<width; i++){
            for (int j=0; j<height-3; j++){
                if (board[i,j] == player && board[i-1,j+1] == player && board[i-2,j+2] == player && board[i-3,j+3] == player)
                    return true;
            }
        }
        // descendingDiagonalCheck
        for (int i=3; i<width; i++){
            for (int j=3; j<height; j++){
                if (board[i,j] == player && board[i-1,j-1] == player && board[i-2,j-2] == player && board[i-3,j-3] == player)
                    return true;
            }
        }
        return false;
    }

    public int GetNumberOfAdjacentEnemies(int x, int y, bool isPlayer) {
        int numberOfEnemies = 0;
        for (int i = x-1; i < x+1; i++) {
            for (int j = y-1; j < y+1; j++) {
                if (i == x && j == y) continue;
                if (!IsWithinBounds(i,j)) continue;
                if (board[i,j] == (isPlayer ? 1 : 2)) continue;
                if (board[i,j] == (isPlayer ? 2 : 1)) numberOfEnemies++;
            }   
        }
        return numberOfEnemies;
    }
}

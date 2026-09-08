public class Solution {
    private char[][] board;
    private int rows, cols;
    public void Solve(char[][] board) {
        this.board = board;
        rows = board.Length;
        cols = board[0].Length;

        // 1. From every boder '0' marck all conected '0's as Safe ('S')
        for (int r = 0; r < rows; r++) {
            Dfs(r, 0); // first column
            Dfs(r, cols - 1); // right column
        }
        for (int c = 0; c < cols; c++) {
            Dfs(0, c); // first row
            Dfs(rows - 1, c); // last row
        }

        // 2. Walk the board and finalize
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (board[r][c] == 'O') {
                    board[r][c] = 'X'; // not safe-> add it as X
                } else if (board[r][c] == 'S'){
                    board[r][c] = 'O'; // safe -> restore it
                }
            }
        }
        
    }

    private void Dfs(int r, int c) {
        if (r < 0 || r >= rows 
        || c < 0 || c >= cols ||
        board[r][c] != 'O')
            return;

        // Mark it as safe
        board[r][c] = 'S';
        Dfs(r + 1, c); //down
        Dfs(r - 1, c); // up
        Dfs(r, c + 1); //right
        Dfs(r, c - 1); //left
    }
}

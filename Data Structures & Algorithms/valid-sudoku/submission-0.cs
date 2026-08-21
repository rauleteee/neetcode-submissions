public class Solution {
    public bool IsValidSudoku(char[][] board) {
    // One set per row, per column, per box
    HashSet<char>[] rows = new HashSet<char>[9];
    HashSet<char>[] cols = new HashSet<char>[9];
    HashSet<char>[] boxes = new HashSet<char>[9];
    for (int i = 0; i < 9; i++) {
        rows[i] = new HashSet<char>();
        cols[i] = new HashSet<char>();
        boxes[i] = new HashSet<char>();
    }

    for (int r = 0; r < 9; r++) {
        for (int c = 0; c < 9; c++) {
            char val = board[r][c];
            if (val == '.') continue;

            int boxIndex = (r / 3) * 3 + (c / 3);   // Flatten 2D arrays with cells: 
                                                    // boxIndex = row * width + col 

            // If val already appeared in this row, column, or box → invalid
            if (rows[r].Contains(val) || cols[c].Contains(val) || boxes[boxIndex].Contains(val)) {
                return false;
            }

            rows[r].Add(val);
            cols[c].Add(val);
            boxes[boxIndex].Add(val);
        }
    }

    return true;
}
}

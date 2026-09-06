public class Solution {
    public int NumIslands(char[][] grid) {
        int count = 0;

        for(int r = 0; r < grid.Length; r++) {
            for (int c = 0; c < grid[0].Length; c++){
                if(grid[r][c] == '1') { // found new land
                    count++; // count this land
                    Sink(grid, r, c); //sink the whole island
                }
            }
        }
        return count;
    }

    private void Sink(char[][] grid, int r, int c) {
        // turn this land and all conected into water
        if (r < 0 ||
        r >= grid.Length ||
        c < 0 ||
        c >= grid[0].Length ||
        grid[r][c] == '0') {
            return;
        }

        grid[r][c] = '0';
        // Recursively turn to zero 
        Sink(grid, r + 1, c); //down
        Sink(grid, r - 1, c); // up
        Sink(grid, r, c + 1); // right
        Sink(grid, r, c - 1); // left
    }
}

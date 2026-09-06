public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        
        int max = 0;
        int area = 0;
        for (int r = 0; r < grid.Length; r++) {
            for (int c = 0; c < grid[0].Length; c++) {
                area = CalculateIslandArea(grid, r ,c);
                max = Math.Max(max, area);
            }
        }
        return max;

    }

    private int CalculateIslandArea(int[][] grid, int r, int c) {

        if(r < 0 || r >= grid.Length ||
        c < 0 || c >= grid[0].Length ||
        grid[r][c] == 0) {
            return 0;
        }

        grid[r][c] = 0;

        return 1 +  
        CalculateIslandArea(grid, r + 1, c) + 
        CalculateIslandArea(grid, r - 1, c) +    
        CalculateIslandArea(grid, r, c + 1) + 
        CalculateIslandArea(grid, r, c - 1);

    }
}

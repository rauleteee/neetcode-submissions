public class Solution {

    private int rows, cols;
    private int[][] heights;

    public List<List<int>> PacificAtlantic(int[][] heights) {
        this.heights = heights;
        rows = heights.Length;
        cols = heights[0].Length;

        // Two grid to mark which cells can reach each ocean
        bool[,] pacific = new bool[rows, cols];
        bool[,] atlantic = new bool[rows, cols];

        // Start DFS from Pacific edges: top row and left column:
        for (int c = 0; c < cols; c++) Dfs(0, c, pacific);
        for (int r = 0; r < rows; r++) Dfs(r, 0, pacific);

        // Start DFS from Atlantic edges: bottom row and right column:
        for (int c = 0; c < cols; c++) Dfs(rows - 1, c, atlantic);
        for (int r = 0; r < rows; r++) Dfs(r, cols - 1, atlantic);

        // Collect cells reachable from BOTH oceans
        List<List<int>> result = new List<List<int>>();
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if(pacific[r,c] && atlantic[r,c])
                    result.Add(new List<int>{r, c});
            }
        }

        return result;
        
    }

    // DFS uphill: from (r,c) vosot neighbors that are EQUAL or HIGHER
    private void Dfs(int r, int c, bool[,] ocean) {
        ocean[r,c] = true; // this cell can reach the ocean we started from

        int[][] dirs = {new[]{1,0},new[]{-1,0},new[]{0,1},new[]{0,-1}};

        foreach(var dir in dirs) {
            int nr = r + dir[0];
            int nc = c + dir[1];

            // Go to neighbor only if: in bounds, not visited, and height is EUQAL or HIGHER
            if(nr >= 0 && nr < rows &&
            nc >= 0 && nc < cols &&
            !ocean[nr,nc] && // not visited as it starts from all false
            heights[nr][nc] >= heights[r][c] // uphill(backwards flow)
            )
            Dfs(nr,nc, ocean);
        }

    }

}

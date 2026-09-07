public class Solution {
    public int OrangesRotting(int[][] grid) {
        if(grid == null || grid.Length == 0) return -1;

        // Put all the rotten oranges in a Queue
        Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
        int fresh = 0;

        for (int r = 0; r < grid.Length; r++) {
            for (int c = 0; c < grid[0].Length; c++) {
                if(grid[r][c] == 2)
                    queue.Enqueue((r,c));
                else if (grid[r][c] == 1)
                    fresh++;
            }
        }

        // 4 directions
        int[][] directions = new int[][]{
            new int[]{1,0}, new int[]{-1,0}, new int[]{0,1}, new int[]{0,-1}
        };

        int minutes = 0;

        while(queue.Count > 0 && fresh > 0) {
            // spread the ripples onwards
            int size = queue.Count;

            for (int i = 0; i < size; i++) {

                var (r,c) = queue.Dequeue();

                foreach(var dir in directions) {
                    int nr = r + dir[0];
                    int nc = c + dir[1];

                    // Spread into land only if it is inbounds and still untouched (1)
                    if (nr >= 0 && nr < grid.Length &&
                        nc >= 0 && nc < grid[0].Length &&
                        grid[nr][nc] == 1) {
                            // fresh fruits become rotten
                            grid[nr][nc] = 2;
                            fresh--;

                            queue.Enqueue((nr, nc));
                    }
                }   
            }
            
            minutes++;
        }
        
        return fresh == 0 ? minutes : -1;
    }
}

public class Solution {
    public void islandsAndTreasure(int[][] grid) {
        int INF = 2147483647;
        int rows = grid.Length;
        int cols = grid[0].Length;

        Queue<(int r, int c)> queue = new Queue<(int r, int c)>();

        // 1. Put all the treasures into the queue (ripple sources)
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == 0) {
                    queue.Enqueue((r,c)); // Queue = [treasure1 (r1,c1), treasure2(r2,c2)]
                }
            }
        }

        // The 4 directions: down, up, right, left
        int[][] dirs = new int[][] {
            new int[]{1,0}, new int[]{-1,0}, new int[]{0, 1}, new int[]{0, -1}
        };

        // 2. SPREAD THE RIPPLES OUTWARDS
        while(queue.Count > 0) {
            var (r,c) = queue.Dequeue(); // take the next cell (front of queue)

            foreach(var dir in dirs) {
                // Look at its four neighbors
                int nr = r + dir[0];
                int nc = c + dir[1];

                // Spread only into land only if it is in bounds AND still INF (untouched)
                if (nr >= 0 && nr < rows &&
                    nc >= 0 && nc < cols &&
                    grid[nr][nc] == INF) {
                        grid[nr][nc] = grid[r][c] + 1;// one step further than me
                        queue.Enqueue((nr,nc)); // this cell ripples next
                    }
            }
        }

    }
}

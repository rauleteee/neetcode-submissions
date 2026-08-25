public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int m = matrix.Length; // number of rows
        int n = matrix[0].Length; // number of columns

        int left = 0;
        int right = m * n - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;

            // Convert the flat index "mid" into a row and column
            int row = mid / n;
            int col = mid % n;
            int value = matrix[row][col];

            if (value == target) return true;
            else if (value < target) left = mid + 1;
            else{ right = mid - 1; }
        }
        return false;
    }
}

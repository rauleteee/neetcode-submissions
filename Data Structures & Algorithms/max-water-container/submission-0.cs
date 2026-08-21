public class Solution {
    public int MaxArea(int[] heights) {

        // Two pointer solution for O(n) instead of O(n2)
        int left = 0;
        int right = heights.Length - 1;
        int maxWater = 0; 

        while(left < right) {

            // Height is limited by the shorter bar; width is the gap
            int h = Math.Min(heights[left], heights[right]);
            int width = right - left;
            int area = h * width;
            
            maxWater = Math.Max(maxWater, area);

            if(heights[left] < heights[right]) {
                left++;
            } else {
                right--;
            }
        }

        return maxWater;
    }
}


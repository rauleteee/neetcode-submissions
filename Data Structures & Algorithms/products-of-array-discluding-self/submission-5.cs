public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int[] right = new int[n];
        int[] left = new int[n];
        int[] result = new int[n];

        // Pass 1: result[i] = product of everything to the LEFT of i
        left[0] = 1;
        for (int i = 1; i < n; i++) {
            left[i] = left[i - 1] * nums[i - 1];
        }

        // Pass 2: multiply in the product of everything to the RIGHT of i
        right[n - 1] = 1;
        for (int i = n - 2; i >= 0; i--)
        {
            right[i] = nums[i + 1] * right[i + 1];
        }
        // then the result is right * left
        for(int i = 0; i < nums.Length; i++)
        {
            result[i] = right[i] * left[i];
        }

        return result;
    }
}
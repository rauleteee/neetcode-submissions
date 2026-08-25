public class Solution {
    public int FindMin(int[] nums) {
        int left = 0;
        int right = nums.Length - 1;

        while(left < right) { // < not <= explanied below
            int mid = left + (right - left) / 2;
            if (nums[mid] > nums[right])
            // minimum is in the right half
                left = mid + 1;
            else 
            // The right half is sorted -> minimum is mid or to its LEFT
                right = mid;  // KEEP MID IT MIGHT BE THE MINIMUM
        }

        return nums[left];
    }
}

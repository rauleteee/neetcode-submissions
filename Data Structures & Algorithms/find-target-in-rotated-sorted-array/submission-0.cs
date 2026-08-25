public class Solution {
    public int Search(int[] nums, int target) {
       int left = 0;
       int right = nums.Length - 1;

       while (left <= right) {
        int mid = left + (right - left) / 2;
        if (nums[mid] == target) return mid; // found it

        // it is like to do two Binary searches in the two halfs

        // decide which half is sorted by comparing mid with the left end
        if (nums[left] <= nums[mid]) {
            if (nums[left] <= target && target < nums[mid])
            // target is in the sorted left half
                right = mid - 1;
            else
            // target is in the other half
                left = mid + 1;
        } else {
            // RIGHT hald [mid...right] is sorted
            if (nums[mid] <= target && target <= nums[right]) {
                left = mid + 1; // target is in the sorted right half
            } else {
                right = mid - 1; // target is in the other half
            }
        }
       }
       return -1; // not found
    }
}

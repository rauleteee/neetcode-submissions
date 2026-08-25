public class Solution {
    public int Search(int[] nums, int target) {
       int left = 0;
       int right = nums.Length - 1;

       while (left <= right) {
        int mid = left + (right - left) / 2;
        // 4. now 6 > 1 then we enter here, mid = 3+(5-3)/2=4
        if (nums[mid] == target) return mid; // found it

        // it is like to do two Binary searches in the two halfs
        // 1. ex nums = [3,4,5,6,1,2]
        // 1. target = 1
        // decide which half is sorted by comparing mid with the left end
        if (nums[left] <= nums[mid]) {
            //2.  if 3 <= 5 -> yes
            if (nums[left] <= target && target < nums[mid])
            // 2. if 3 <= 1 NO
            // target is in the sorted left half
                right = mid - 1;
            else
            // target is in the other half
            // 3. we know 1 is in the right half, now left = 3
                left = mid + 1;
        } else {
            
            // RIGHT half [mid...right] is sorted
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

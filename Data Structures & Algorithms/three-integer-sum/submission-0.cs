public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        List<List<int>> result = new List<List<int>>();

        // First we sort the array to eliminate duplicates
        // and avoid same combinations
        Array.Sort(nums); //[-4,-1,-1,0,1,2] two pointers sweep

        for(int i = 0; i < nums.Length - 2; i++) {
            // skip duplicates
            if(i > 0 && nums[i] == nums[i-1]) continue;

            // Now it's Two Sum II
            int left = i + 1;
            int right = nums.Length - 1;
            int target = -nums[i];
            
            while(left < right) {
                int sum = nums[left] + nums[right];

                if(sum == target) {
                    result.Add(new List<int>{nums[i], nums[left], nums[right]});

                    // Skip duplicates on both sides before moving on
                    while (left < right && nums[left] == nums[left+1]) left++;
                    while (left < right && nums[right] == nums[right-1]) right--;

                    // next
                    left++;
                    right--;
                } else if (sum > target) {
                    right--;
                } else {
                    left++;
                }
            }
        }
        return result;
    }
}

public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> result = new List<List<int>>();
        Backtrack(0, nums, new List<int>(), result);
        return result;

        
    }

    private void Backtrack(int i, int[] nums, List<int> current, List<List<int>> result) {
        if( i == nums.Length) {
            result.Add(new List<int>(current)); // reached the end -> save a copyt of this subset
            return;
        }

        // Choice 1: INCLUDE nums[]
        current.Add(nums[i]);

        Backtrack(i + 1, nums, current, result);

        // Choice 2: EXCLUDE nums[i] (undo the include then explore without it)
        current.RemoveAt(current.Count - 1);

        Backtrack(i + 1, nums, current, result);
    }
}

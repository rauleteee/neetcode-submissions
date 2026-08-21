public class Solution {
    public int LongestConsecutive(int[] nums) {
        HashSet<int> set = new HashSet<int>(nums);  // all numbers, instant lookups
        int longest = 0;

        foreach(int num in set)
        {
            // Only start counting if this is the beginning of a sequence
            if(!set.Contains(num - 1))
            {
                int length = 1;
                int current = num;

                // Walk upward while the next number exists
                while(set.Contains(current + 1)){
                    current++;
                    length++;
                }
                longest = Math.Max(longest, length);
            }

        }
        return longest;
        
    }
}

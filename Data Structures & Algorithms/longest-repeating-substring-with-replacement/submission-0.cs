public class Solution {
    public int CharacterReplacement(string s, int k) {
        int[] count = new int[26];
        int left = 0; // counts of each letter in the current window
        int maxCount = 0; // highest single-letter count in the window
        int longest = 0; 

        for (int right = 0; right < s.Length; right++) {
            count[s[right] - 'A']++;
            maxCount = Math.Max(maxCount, count[s[right] - 'A']);

            // If the window needs more than k replacements, shrink it
            while ((right - left + 1) - maxCount > k) {
                count[s[left] - 'A']--;
                left++;
            }

            longest = Math.Max(longest, right - left + 1);
        }

        return longest;
    }
}

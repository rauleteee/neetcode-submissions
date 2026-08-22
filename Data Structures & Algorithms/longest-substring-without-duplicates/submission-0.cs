public class Solution {
    public int LengthOfLongestSubstring(string s) {
        HashSet<char> window = new HashSet<char>();
        int left = 0;
        int longest = 0;

        for(int right = 0; right < s.Length; right++) {
            // if the new char is already in the window, shrink from the left
            while (window.Contains(s[right])) {
                window.Remove(s[left]);
                left++;
            }
            
            // Now the window has no duplicate, add the new char
            window.Add(s[right]);

            // Record the last longest window size
            longest = Math.Max(longest, right - left + 1);

        }
        return longest;
    }
}

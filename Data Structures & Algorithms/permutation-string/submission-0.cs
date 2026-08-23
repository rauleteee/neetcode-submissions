public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        // if s1 > s2 there will be no valid permutations
        if(s1.Length > s2.Length) return false;

        char[] a = s1.ToCharArray(); //[a,c,b]
        Array.Sort(a); // [a,b,c]
        string sortedS1 = new string(a); //"abc"

        // Now we compare it to the sorted string s2
        for(int i = 0; i + s1.Length <= s2.Length; i++) {
            // We use sliding window to compare the substrings
            char[] window = s2.Substring(i, s1.Length).ToCharArray();
            // the window needs to have at least s1 length minus 
            // the left pointer s2[s1.Length] taking pointers in account
            Array.Sort(window);
            if(new string(window) == sortedS1) return true;
        }
        return false;
    }
}

public class Solution {
    public bool IsAnagram(string s, string t) {

        char[] a = s.ToCharArray();
        char[] b = t.ToCharArray();

        Array.Sort(a);
        Array.Sort(b);
        return new string(a) == new string(b);
        /*
        "carrace"  →  sorted  →  "aaccerr"
        "racecar"  →  sorted  →  "aaccerr"
        */
    }
}

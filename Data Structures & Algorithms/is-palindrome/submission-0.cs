public class Solution {
    public bool IsPalindrome(string s) {

        StringBuilder sb = new StringBuilder();

        // step1 build a clean lowercase string
        foreach(char c in s){
            if(char.IsLetterOrDigit(c)){
                sb.Append(char.ToLower(c));
            }
        }
        string clean = sb.ToString();

        //step2 compare position i with its mirror
        int n = clean.Length;
        for(int i = 0; i < n/2; i++){
            if(clean[i] != clean[n - 1 - i]){
                return false;
            }
        }

        return true;
    }
}

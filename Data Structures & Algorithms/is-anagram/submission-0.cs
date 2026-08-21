public class Solution {
    public bool IsAnagram(string s, string t) {

        if (s.Length != t.Length){
            return false;
        }
        
        // Count how many times each letter appears in s
        Dictionary<char, int> counts = new Dictionary<char, int>();
        foreach(char letter in s){
            if(counts.ContainsKey(letter)){
                counts[letter]++;
            }else{
                counts[letter] = 1;
            }
        }
        
        // Go through t and substract each letter from the count
        foreach(char letter in t){
            if(!counts.ContainsKey(letter)) return false;

            counts[letter]--;
            // If it goes negative, t has more of this letter than s
            if(counts[letter] < 0 ) return false;
        }

        // If lengths match and no count went negative, they're anagrams
        return true;

    }
}

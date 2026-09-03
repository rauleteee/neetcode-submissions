public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();

        foreach (string s in strs){
            char[] c = s.ToCharArray();
            Array.Sort(c);
            string key = new string(c); // now we have sorted array: act, act, pots, pots pots hat

            // Put the word in the bucket for that key
            if(!groups.ContainsKey(key)){
                groups[key] = new List<string>(); // [{"act":"", "...":"",...}
            }
            groups[key].Add(s);// [{"act":"act", "cat"}, {"stop": "stop", "pots", "tops"}, {"hat": "hat"}]
        }

        return new List<List<string>>(groups.Values); // return only Values from dictionary Key-> Value
        
    }
}

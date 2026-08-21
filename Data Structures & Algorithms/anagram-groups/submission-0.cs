public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();

        foreach (string s in strs){
            char[] c = s.ToCharArray();
            Array.Sort(c);
            string key = new string(c); // now we have sorted string

            Console.WriteLine($"Word: \"{s}\"  ->  sorted key: \"{key}\"");

            // Put the word in the bucket for that key
            if(!groups.ContainsKey(key)){
                groups[key] = new List<string>();
                Console.WriteLine($"   New bucket created for key \"{key}\"");
            }else{
                Console.WriteLine($"   Bucket \"{key}\" already exists");
            }

            groups[key].Add(s);
            Console.WriteLine($"   Bucket \"{key}\" now contains: [{string.Join(", ", groups[key])}]");
            Console.WriteLine();
        }

        Console.WriteLine("=== Final groups ===");
        foreach (var pair in groups) {
            Console.WriteLine($"Key \"{pair.Key}\"  ->  [{string.Join(", ", pair.Value)}]");
        }

        return new List<List<string>>(groups.Values);
        
    }

    
}

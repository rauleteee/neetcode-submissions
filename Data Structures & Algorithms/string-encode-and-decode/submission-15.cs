public class Solution {

    public string Encode(IList<string> strs) {
        // o(n), ["code", "co#de"] ->[Length][Delimiter][String] s = "4#code5#co#de"
        StringBuilder sb = new StringBuilder();
        foreach (string s in strs) {
            sb.Append(s.Length);   // how long this string is
            sb.Append('#');        // marker separating the length from the content
            sb.Append(s);          // the actual string
        }
        return sb.ToString();
        
    }

    public List<string> Decode(string s) {
        List<string> result = new List<string>();
        int i = 0;
        while (i < s.Length) {
            // Read digits until we hit '#' → that's the length
            int j = i;
            while (s[j] != '#') {
                j++; // number of the digits of the length
            }
            // Take the length without 
            int length = int.Parse(s.Substring(i, j - i));

            // The string starts right after '#' and runs 'length' chars
            string str = s.Substring(j + 1, length);
            result.Add(str);

            // Jump past this whole chunk to the next one
            // next chunk will start in length + number of digits of the length(j) + delimiter
            i = j + 1 + length;
        }
        return result;
    }
}

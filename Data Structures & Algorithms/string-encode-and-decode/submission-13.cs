public class Solution {

    public string Encode(IList<string> strs) {
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
                j++;
            }
            int length = int.Parse(s.Substring(i, j - i));

            // The string starts right after '#' and runs 'length' chars
            string str = s.Substring(j + 1, length);
            result.Add(str);

            // Jump past this whole chunk to the next one
            i = j + 1 + length;
        }
        return result;
    }
}

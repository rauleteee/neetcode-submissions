public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();

        foreach(char c in s) {
            if (c == '(' || c == '{' || c== '[') { stack.Push(c); }
            else {
                // close bracket → the top of the stack must be the matching open
                if (stack.Count == 0) return false;   // nothing open to match
                /*
                Pop() does two things: it takes the top item off the stack, and it gives you that item. So top now holds the most recent open bracket, and the stack has removed it. You are saying: "Let me take the last open bracket and see if it matches this close bracket."
                */
                char top = stack.Pop();
                if (c == ')' && top != '(') return false;
                if (c == ']' && top != '[') return false;
                if (c == '}' && top != '{') return false;
            }
        }
                /*Trace on "([{}])":

        '(' → push        → stack: (
        '[' → push        → stack: ( [
        '{' → push        → stack: ( [ {
        '}' → pop '{' ✓   → stack: ( [
        ']' → pop '[' ✓   → stack: (
        ')' → pop '(' ✓   → stack: (empty)
        end → stack empty → return true  ✓*/
        return stack.Count == 0;
    }
}

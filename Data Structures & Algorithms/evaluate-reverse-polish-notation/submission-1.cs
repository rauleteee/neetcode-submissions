public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();
        //tokens = ["1","2","+","3","*","4","-"]

        foreach(string token in tokens) {
            if (token == "+" || token == "-" || token == "/" || token == "*") {
                // operator: pop the two most recent numbers
                // a = 2, b = 1

                int b = stack.Pop();
                int a = stack.Pop();
                int result = 0;
                if (token == "+") result = a + b;
                else if (token == "-") result = a - b;
                else if (token == "*") result = a * b;
                else if (token == "/") result = a / b; // C# truncates towards 0

                // Then push the result into the stack
                stack.Push(result);
            } else {
                stack.Push(int.Parse(token)); // just push it into the stack
            }
        }
        // The final answer is the only number left on the stack
        return stack.Pop();
    }
}

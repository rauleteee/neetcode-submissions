public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        int n = temperatures.Length;
        int[] result = new int[n];
        Stack<int> stack = new Stack<int>();

        for( int i = 0; i < n; i++) {
            // Is today (i) warmer than the day waiting on top of the stack?
            // If yes, today is the answer for that waiting day. Keep checking,
            // because today might be warmer than several waiting days.
            while(stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()]) {
                int previousDay = stack.Pop();
                result[previousDay] = i - previousDay;
            }
            // Today has no warmer day yet, so today waits too. Push its index.
            stack.Push(i);
        }
        return result;
    }
}

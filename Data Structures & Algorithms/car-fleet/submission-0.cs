public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        int n = position.Length;

        // step1 make a list of indices;
        int[] indices = new int[n];
        for (int i = 0; i < n; i++)
            indices[i] = i;

        // step2 sort the indices which are closer to the target, biggest first
        Array.Sort(indices, (a,b) => position[b] - position [a]);

        //step3 go front to back, using a stack of fleet arrival time
        Stack<double> stack = new Stack<double>();
        foreach(int i in indices) {
            double time = (double)(target - position[i]) / speed[i];

            // if the one in front of the current is slower, it'll create a new fleet
            if(stack.Count == 0 || time > stack.Peek()) {
                stack.Push(time);
            }
        }

        return stack.Count;
    }
}

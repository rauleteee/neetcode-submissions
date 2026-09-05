public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        // Count how many times each task appears
        int[] counts = new int[26];
        foreach(int task in tasks) {
            counts[task - 'A']++;
        }

        // Find the highest count, the most frequent task = bottleneck
        int maxCount = 0;
        foreach(int c in counts) {
            maxCount = Math.Max(maxCount, c);
        }

        // Count how many tasks share the highest count
        int numMax = 0;
        foreach(int c in counts) {
            if (c == maxCount)
                numMax++;
        }

        // Formula arrange the most frequent task with cooldown gaps, then fill
        int frame = (maxCount - 1) * (n + 1) + numMax;

        // If there are more tasks than the frame, they fill all gaps -> no idle time
        return Math.Max(frame, tasks.Length);

    }
}

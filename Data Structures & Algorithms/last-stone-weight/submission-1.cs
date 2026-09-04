public class Solution {
    public int LastStoneWeight(int[] stones) {
        // Put all the rocks in the "magic bag" that keeps the biggest on top
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();
        foreach (int stone in stones) {
            maxHeap.Enqueue(stone, -stone); // the "-" put the biggest at the start of the heap
        }

        // Keep playing until there are at least 2 rocks
        while (maxHeap.Count > 1) {
            int y = maxHeap.Dequeue(); // take the heaviest rock
            int x = maxHeap.Dequeue(); // take the second heaviest rock

            if (y != x) { // Different weights??
                maxHeap.Enqueue(y - x, -(y - x)); // the leftover rock goes back
            }
            // if x == y they disappear -> do nothing
        }
        // One rock left → return its weight. No rocks left → return 0.
        return maxHeap.Count == 1 ? maxHeap.Dequeue() : 0;
    }
}

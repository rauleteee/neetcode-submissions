public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        // Max-heap exercise
        PriorityQueue<int[], int> maxHeap = new PriorityQueue<int[], int>();
        foreach(int[] point in points) {
            int dist = point[0] * point[0] + point[1] * point[1]; //// x² + y² (no sqrt)

            maxHeap.Enqueue(point, -dist); // closest first

            // if we have more than k points remove the farthest
            if(maxHeap.Count > k) {
                maxHeap.Dequeue();
            }

        }
        // Whatever remains in the maxHeap are the k closest points
        int[][] result = new int[k][];
        for (int i = 0; i < k; i++) {
            result[i] = maxHeap.Dequeue();
        }

        return result;
    }
}

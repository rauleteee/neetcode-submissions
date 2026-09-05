public class Solution {
    public int FindKthLargest(int[] nums, int k) {

        PriorityQueue<int,int> minHeap = new PriorityQueue<int,int>();
        foreach(int num in nums) {
            minHeap.Enqueue(num, num);
            // remove the smallets if we have more than k
            if (minHeap.Count > k)
                minHeap.Dequeue();
        } // create the heap with the largest numbers at the beginning
        
        return minHeap.Peek();
    }
}

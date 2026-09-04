public class KthLargest {

    private PriorityQueue<int, int> minHeap; // min-heap: smallest at the top
    private int k;

    public KthLargest(int k, int[] nums) {
        this.k = k;
        minHeap = new PriorityQueue<int,int>(); // in C#, first value = item, second = priority

        // Add all starting numbers keeping only the k largest ones
        foreach(int num in nums){
            Add(num);
        }
        
    }
    
    public int Add(int val) {
        // Add the new value (item and priority are both 'val' so it sorts by value)
        minHeap.Enqueue(val, val);

        // If we have more than k items, remove the smallest
        if(minHeap.Count > k) {
            minHeap.Dequeue(); // top of min-heap
        }

        // the to pof the heap is now the kth largest
        return minHeap.Peek();
    }
}

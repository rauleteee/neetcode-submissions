/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public void ReorderList(ListNode head) {
        if (head == null || head.next == null) return;

        // 1. Copy nodes into an array/list
        List<ListNode> nodes = new List<ListNode>();
        ListNode curr = head;
        while (curr != null) {
            nodes.Add(curr);
            curr = curr.next;
        }

        // 2. Re-link using two pointers from opposite ends
        int left = 0;
        int right = nodes.Count - 1;

        while (left < right) {
            nodes[left].next = nodes[right];
            left++;

            if (left == right) break;

            nodes[right].next = nodes[left];
            right--;
        }

        // 3. Mark the tail to prevent infinite loops
        nodes[left].next = null;
    }
}

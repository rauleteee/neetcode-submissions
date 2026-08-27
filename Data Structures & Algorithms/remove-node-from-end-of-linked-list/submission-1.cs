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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        // 1. Count the length of the list
        int length = 0;
        ListNode curr = head;
        while(curr != null) {
            length++;
            curr = curr.next;
        }

        // 2. The node to remove is at (length - n) position from the start. We want to stop at the node JUST BEFORE IT. A dummy node in front makes removing the first node easy:
        ListNode dummy = new ListNode();
        dummy.next = head;

        ListNode prev = dummy;
        // Move prev forward (length - n) times to reach the node beefore the target
        for(int i = 0; i < length - n; i++) {
            prev = prev.next;
        }
        // 3. skip the target node by pointing around it
        prev.next = prev.next.next;
        
        return dummy.next; // real head (handles removing the firs node)
    }
}

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
    public bool HasCycle(ListNode head) {
        // We can use a hashset to see if we've already visited a node
        HashSet<ListNode> seen = new HashSet<ListNode>();
        ListNode curr = head;

        while(curr != null) {
            if(seen.Contains(curr))
                return true;
            seen.Add(curr);
            curr = curr.next;
        }
        return false;
    }
}

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
    public ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        ListNode curr = head;

        while(curr != null) {
            ListNode nextTemp = curr.next; // save the next node before we lose it
            curr.next = prev; // flip point current backward
            prev = curr; // move prev forward to current
            curr = nextTemp; // move current forward to the saved next
        }
        return prev; // prev is now the new head (the old )
    }
}

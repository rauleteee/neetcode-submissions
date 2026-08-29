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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        // Fake start
        ListNode dummy = new ListNode();
        ListNode tail = dummy; // point to the last node
        int carry = 0; // if the sum >= 10

        // continue until the nodes are left in either list, or a carry remains
        while (l1 != null || l2 != null || carry != 0) {
            // Get the current digit of each list (0 if that list has ended)
            int digit1 = (l1 != null) ? l1.val : 0;
            int digit2 = (l2 != null) ? l2.val : 0;

            int sum = digit1 + digit2 + carry;
            carry = sum / 10; // 1 if sum is 10 or more, 0 if less than 10
            int newDigit = sum % 10; // move the sum pointer

            // Attach a new node with the new digit
            tail.next = new ListNode(newDigit);
            tail = tail.next;

            // Move forward in each list if there is still any other nodes left
            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;

        }

        // the real head is after the dummy
        return dummy.next;
    }
}

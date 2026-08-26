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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        // dummy node: first dummy node so we dont need special code for the first one
        ListNode dummy = new ListNode();
        ListNode tail = dummy; // tail always point to the last node added

        // while BOTH lists have nodes, pick the smaller front node
        while(list1 != null && list2 != null) {
            if (list1.val <= list2.val) {
                tail.next = list1; // atach list1's node
                list1 = list1.next; // move forward in list1
            } else {
                tail.next = list2;
                list2 = list2.next;
            }
            tail = tail.next; // move tail to the node we just added
        }
        // one list is now empty, attach whatever is left of the other
        if (list1 != null) {
            tail.next = list1;
        } else {
            tail.next = list2;
        }

        return dummy.next; // the real head is the node after the dummy
    }
}
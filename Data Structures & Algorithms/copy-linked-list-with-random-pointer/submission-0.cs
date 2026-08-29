/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if (head == null) return null;

        // Dictionary maps original node -> its copy
        Dictionary<Node,Node> map = new Dictionary<Node,Node>();

        // 1. Create a copy of all of the nodes
        Node curr = head;
        while (curr != null) {
            map[curr] = new Node(curr.val);
            curr = curr.next;
        }

        // 2. Set NEXT and RANDOM for each copy using the Dictionary
        curr = head;
        while (curr != null) {
            // the copy of the current node
            Node copy = map[curr];

            // Its next copy = the copy of the original node
            copy.next = (curr.next != null) ? map[curr.next] : null;

            // Its random copy = the random copy of the original node
            copy.random = (curr.random != null) ? map[curr.random] : null;

            curr = curr.next;
        }
        // return the copy of the original head
        return map[head];
    }
}

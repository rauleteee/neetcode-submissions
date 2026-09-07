/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {

    // Map original node -> its copy
    private Dictionary<Node, Node> map = new Dictionary<Node, Node>();

    public Node CloneGraph(Node node) {
        if (node == null) return null; // base case

        // If we've already copy this node, return its copy
        if (map.ContainsKey(node))
            return map[node];

        // Make a new copy of this node (only value neighbors next)
        Node copy = new Node(node.val);
        map[node] = copy; // RECORD it BEFORE recursing for breaking the loop

        // Copy each neighbor and attach it to the copy
        foreach(Node neighbor in node.neighbors) {
            copy.neighbors.Add(CloneGraph(neighbor));
        }
        return copy;
    }
}

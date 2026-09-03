/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {

    private int count = 0; // how many nodes we've visited so far
    private int result = 0; // the answer

    public int KthSmallest(TreeNode root, int k) {
        InOrder(root, k);
        return result;
    }

    private void InOrder(TreeNode node, int k) {
        if (node == null) return;

        // Visit the left side first (smaller values)
        InOrder(node.left, k);

        // Visit THIS node -IT'S THE NEXT VALUE IN SORTED ORDER
        count++;
        if (count == k) {
            result = node.val; // kth smallest
            return;
        }

        // Visit the right side (bigger values)
        InOrder(node.right, k);
    }
}

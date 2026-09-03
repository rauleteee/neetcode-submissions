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
    public bool IsValidBST(TreeNode root) {

        return IsValid(root, long.MinValue, long.MaxValue);
    }

    private bool IsValid(TreeNode node, long min, long max) {
        if (node == null) return true; // empty node is always valid

        // this node must be strictly inside the range
        if (node.val <= min || node.val >= max) {
            return false;
        }

        // Left subtree: values must be LESS than node.val -> max becomes node.val
        // right subtree: values must be MORE than node.val -> min becomes node.val
        return IsValid(node.left, min, node.val) && IsValid(node.right, node.val, max);
    }
}

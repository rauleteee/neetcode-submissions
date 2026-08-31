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
    public TreeNode InvertTree(TreeNode root) {
        // base case: an empty node has nothing to invert
        if (root == null) return null;

        // swap this node's left and right children
        TreeNode temp = root.left;
        root.left = root.right;
        root.right = temp;

        // recursively invert each child
        InvertTree(root.left);
        InvertTree(root.right);

        return root;
    }
}

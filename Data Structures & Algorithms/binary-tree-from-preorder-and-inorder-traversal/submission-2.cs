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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        // base case: nothing left to build
        if (preorder.Length == 0) return null;

        // 1. the first preorder value is the root
        int rootValue = preorder[0];
        TreeNode root = new TreeNode(rootValue);

        // 2. Find the root in order to split left from right
        int mid = Array.IndexOf(inorder, rootValue);

        // The left part of inorder = left subtree; rihgt part = right subtree
        int[] leftInorder = inorder[0..mid];
        int[] rightInorder = inorder[(mid + 1)..];

        // Preorder: after the root come the left values, then the right values
        int[] leftPreorder = preorder[1..(mid + 1)]; // next mid values
        int[] rightPreorder = preorder[(mid + 1)..]; // the rest

        // Recurse: build each side the same way
        root.left = BuildTree(leftPreorder, leftInorder);
        root.right = BuildTree(rightPreorder, rightInorder);

        return root;
    }
}

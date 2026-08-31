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

    private bool balanced = true;

    public bool IsBalanced(TreeNode root) {
        Height(root);
        return balanced;
    }

    private int Height(TreeNode node) {
        if (node == null) return 0;

        int leftHeight = Height(node.left);
        int rightHeight = Height(node.right);

        // F one node differs more than 1 in height, it is not balanced
        if (Math.Abs(leftHeight - rightHeight) > 1)
            balanced = false;

        return 1 + Math.Max(leftHeight, rightHeight); 
    }
}

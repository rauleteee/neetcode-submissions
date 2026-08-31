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

    private int diameter = 0;

    public int DiameterOfBinaryTree(TreeNode root) {

        Height(root); // this fills diameter as side effect
        return diameter;
    }

    private int Height(TreeNode node) {
        if (node == null) return 0;

        int leftHeight = Height(node.left); // height of left side
        int rightHeight = Height(node.right); // height of right side

        // Path through THIS node = left height + right height (in edges)
        // Check if it is the biggest path we've seen
        diameter = Math.Max(diameter, leftHeight + rightHeight);

        // return the node's height (1 + taller)
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}

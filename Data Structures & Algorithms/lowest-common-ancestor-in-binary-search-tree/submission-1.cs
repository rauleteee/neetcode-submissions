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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {

        TreeNode curr = root;

        while (curr != null) {
            if(p.val < curr.val && q.val < curr.val) {
                // Both are smaller then LCA is in the left side
                curr = curr.left;
            } else if (p.val > curr.val && q.val > curr.val) {
                // Both are larger then LCA is in the right side
                curr = curr.right;
            } else {
                // They split here -> this is the LCA
                return curr;
            }
        }
        return null;
    }
}

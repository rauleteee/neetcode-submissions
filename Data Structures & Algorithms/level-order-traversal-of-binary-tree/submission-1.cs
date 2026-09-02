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
    public List<List<int>> LevelOrder(TreeNode root) {
        List<List<int>> result = new List<List<int>>();
        if(root == null) return result; // empty tree -> empty list

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root); // start with the root

        while(queue.Count > 0){
            int levelSize = queue.Count; // how many nodes are in this level
            List<int> level = new List<int>();

            //Process exactly this level's nodes
            for (int i = 0; i < levelSize; i++) {
                TreeNode node = queue.Dequeue(); // take the front node
                level.Add(node.val); // record its value

                // Add its children (they belon to the NEXT level)
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            result.Add(level);
        }

        return result;
    }
}

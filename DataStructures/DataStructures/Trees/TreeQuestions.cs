using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresExercises.Trees
{
    internal class TreeQuestions
    {

        internal static void Execute()
        {
            var preOrder = new[] { 3, 9, 20, 15, 7 };
            var inOrder = new[] { 9, 3, 15, 20, 7 };
            var tree = BuildTree(preOrder, inOrder);
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        //Input: preorder (NLR) = [3, 9, 20, 15, 7], inorder(LNR) = [9, 3, 15, 20, 7]
        //Output: [3, 9, 20, null, null, 15, 7]
        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || inorder == null || !preorder.Any() || !inorder.Any())
                return null;

            TreeNode root = new TreeNode(preorder[0]);
            int leftNodesIndex = Array.IndexOf(inorder, preorder[0]);
            root.left = BuildTree(preorder[1..(leftNodesIndex+1)], inorder[..leftNodesIndex]);
            root.right = BuildTree(preorder[(leftNodesIndex+1)..], inorder[(leftNodesIndex + 1)..]);
            return root;
        }
    }
}

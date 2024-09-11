using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructuresExercises.Trees
{
    internal static class TreeExtensions
    {
        internal static TreeNode<T> BuildTree<T>(this T[] nodesData,int levelLength)
        {
            var queue = new Queue<TreeNode<T>>();
            var root = new TreeNode<T>(nodesData[0]);
            queue.Enqueue(root);

            int index = 1;
            while (index < nodesData.Length && queue.TryDequeue(out var node))
            {
                while(node.Leafs.Count < levelLength && index < nodesData.Length)
                {
                    var childNode = new TreeNode<T>(nodesData[index++]);
                    node.AddLeaf(childNode);
                    queue.Enqueue(childNode);
                }
            }
            return root;
        }

        internal static void BreadthFirstSearch<T>(this TreeNode<T> root,Action<T> action,T target) where T:IEquatable<T>
        {
            Queue<TreeNode<T>> treeNodes = new Queue<TreeNode<T>>();
            treeNodes.Enqueue(root);
            while (treeNodes.TryDequeue(out var currentTreeNode))
            {
                action(currentTreeNode.Payload);
                if (target.Equals(currentTreeNode.Payload))
                {
                    break;
                }
                
                foreach (TreeNode<T> node in currentTreeNode.Leafs)
                {
                    treeNodes.Enqueue(node);
                }
                
            }
        }

        internal static void DeepFirstSearch<T>(this TreeNode<T> root, Action<T> action, T target) where T : IEquatable<T>
        {
            var nextNodes = new Stack<TreeNode<T>>();
            nextNodes.Push(root);
            while (nextNodes.TryPop(out var currentTreeNode))
            {
                action(currentTreeNode.Payload);
                if (target.Equals(currentTreeNode.Payload)) { break; }

                for (int i = currentTreeNode.Leafs.Count-1; i >=0; i--)
                {
                    nextNodes.Push(currentTreeNode.Leafs[i]);
                }
                
            }
        }


        internal static void PrintTree<T>(TreeNode<T> node, int level = 0)
        {
            if (node == null) return;

            Console.WriteLine(new string(' ', level * 2) + node.Payload);
            foreach (var child in node.Leafs)
            {
                PrintTree(child, level + 1);
            }
        }
    }
}

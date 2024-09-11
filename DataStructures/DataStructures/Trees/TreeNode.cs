using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresExercises.Trees
{
    

    internal class TreeNode<T>
    {
        internal T Payload { get; set; }
        internal TreeNode<T>? Parent { get; set; }

        internal List<TreeNode<T>> Leafs { get; set; }

        public TreeNode(T payload)
        {
            Payload = payload;
            //Parent = parent;
            Leafs = new List<TreeNode<T>>();
        }

        internal void AddLeaf(TreeNode<T> node)
        {
            Leafs.Add(node);
            node.Parent = this;
        }

    }
}

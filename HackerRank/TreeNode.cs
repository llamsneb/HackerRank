using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class TreeNode
    {
        public TreeNode? left;
        public TreeNode? right;
        public int data;

        public TreeNode(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }

        public static TreeNode insert(TreeNode root, int data)
        {
            if (root == null)
            {
                return new TreeNode(data);
            }
            else
            {
                TreeNode cur;
                if (data <= root.data)
                {
                    cur = insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }

        //public static void postOrder(TreeNode root)
        //{
        //    if (root == null)
        //    {
        //        return;
        //    }
        //    postOrder(root.left);
        //    postOrder(root.right);
        //    Console.Write(root.data + " ");
        //}

        //public static void preOrder(TreeNode root)
        //{
        //    if (root == null)
        //    {
        //        return;
        //    }
        //    Console.Write(root.data + " ");
        //    preOrder(root.left);
        //    preOrder(root.right);
        //}
    }
}

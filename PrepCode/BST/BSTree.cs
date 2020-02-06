using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepCode.BST
{
    public class BSTree
    {
        public Node root;
        public BSTree()
        {
            root = null;
        }

        public void Insert(int data)
        {  
           root= InsertNode(data,root);     

        }
        private Node InsertNode(int data,Node root)
        {
            if(root == null)
            {
                root = new Node(data);
                return root;
                
            }
           
                if( root.data > data)
                {
                   root.left= InsertNode(data, root.left);
                }
                else
                {
                   root.right= InsertNode(data, root.right);
                }
            
            return root;

      
        }

        public void DeleteNode(int data,Node root)
        {
            if(root == null)
            {
                return;

            }
            if(root.data > data)
            {
                DeleteNode(data, root.left);
            }
             if(root.data < data)
            {
                DeleteNode(data, root.right);
            }
            if(root.data == data)
            {
                //In this case just simply made the Node null to remove it from the tree
                if (root.left == null && root.right == null)
                    root = null;
                //In this case we need to find the smallest element in the right tree and replace it with the node
               else if(root.left !=null && root.right != null)
                {
                    root.data = minValue(root.right);
                }
                else
                {
                    if(root.left != null)
                    {
                        root.data = root.left.data;
                        root.left = null;
                    }
                    else
                    {
                        root.data = root.right.data;
                        root.right = null;
                    }
                }
            }
        }

        public int minValue(Node root)
        {
            int value = 0;
            while(root.left != null)
            {
                value = root.left.data;
                root = root.left;
            }
            return value;
        }
        /// <summary>
        /// Pre Order is NLR (Node Left Rigth)
        /// </summary>
        /// <param name="root"></param>

        public void Preorder(Node root)
        {
            if (root == null)
                return;
            Console.WriteLine(root.data);
            Preorder(root.left);
            Preorder(root.right);

        }

        //public Node createNode(int data)
        //{
        //    //Node item = new Node();
        //    //item.data = data;
        //    //item.left = null;
        //    //item.right = null;
        //    //return item;
        //}
    }
}

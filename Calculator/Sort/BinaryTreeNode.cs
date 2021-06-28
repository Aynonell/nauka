using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public class BinaryTreeNode
    {
        public double Value;
        public BinaryTreeNode LeftChild;
        public BinaryTreeNode RightChild;
        public BinaryTreeNode(double value)
        {
            Value = value;
        }
        public void Insert(double value, BinaryTreeNode node)
        {
            if(node == null)
            {
                throw new ArgumentNullException("Wywołanie BinaryTreeNode z jakimś nulem ...") ;   
            }    
            if (node.Value > value)
            {
                if (node.LeftChild?.Value != null)
                {
                    Insert(value, node.LeftChild);
                }
                else
                {
                    node.LeftChild = new BinaryTreeNode(value);
                }
            }
            else
            {
                if (node.RightChild?.Value != null)
                {
                    Insert(value, node.RightChild);
                }
                else
                {
                    node.RightChild = new BinaryTreeNode(value);
                }
            }
        }
        public void Print(BinaryTreeNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Wywołanie Print z jakimś nulem ...");
            }

            if (node.LeftChild?.Value != null)
            {
                Print(node.LeftChild);
            }

            Console.WriteLine("{0:0.00}",node.Value);

            if (node.RightChild?.Value != null)
            {
                Print(node.RightChild);
            }
        }
        public void TreeToList(BinaryTreeNode node,List<double> Sorted)
        {
            if (node == null || Sorted == null)
            {
                throw new ArgumentNullException("Wywołanie TreeToList z jakimś nulem ...");
            }
            if (node.LeftChild?.Value != null)
            {
                TreeToList(node.LeftChild,Sorted);
            }

            Sorted.Add(node.Value);

            if (node.RightChild?.Value != null)
            {
                TreeToList(node.RightChild,Sorted);
            }
        }


    }
}

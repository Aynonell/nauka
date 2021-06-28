using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public class BinaryTree
    {

        BinaryTreeNode Tree;

        public BinaryTree(Items numbers)
        {
            // Insert first element to tree
            Tree = new BinaryTreeNode(numbers.Source[0]);

            for (int i = 1; i < numbers.Source.Count; i++)
            {
                Tree.Insert(numbers.Source[i],Tree);
            }
            Tree.TreeToList(Tree,numbers.Sorted);
            numbers.isSorted = true;
        }
        
    }

}

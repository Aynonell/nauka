using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Tasks.Task4
{
    public class Tree
    {
        public int summary;
        int minValue = 0;
        int maxValue = 100;
        int maxNodeCount = 10000;
        public Tree(int?[] root)
        {
            if (root.Length > maxNodeCount)
            {
                throw new ArgumentException("Zbyt duża ilość nodów");
            }
            if (root.Count(x => x > maxValue || x < minValue) > 0)
            {
                throw new ArgumentOutOfRangeException("Wartość węzła większa od założonych");
            }
            Queue queueItems = new Queue();
            int index = 0;
            TreeNode myTree = new TreeNode(root[index++]);
            queueItems.Enqueue(myTree);
            while (queueItems.Count > 0)
            {
                if (index < root.Length)
                {
                    var q = queueItems.Dequeue() as TreeNode;
                    q.left = new TreeNode(root[index]);
                    if (q.left.value != null)
                    {
                        queueItems.Enqueue(q.left);
                    }
                    index++;
                    if (index < root.Length)
                    {
                        q.right = new TreeNode(root[index]);
                        index++;
                        if (q.right.value != null)
                        {
                            queueItems.Enqueue(q.right);
                        }
                    }
                }
                else
                {
                    int? suma = 0;
                    while (queueItems.Count > 0)
                    {
                        suma += (queueItems.Dequeue() as TreeNode)?.value;
                    }
                    summary = (int)suma;
                }
            }

        }
    }
}

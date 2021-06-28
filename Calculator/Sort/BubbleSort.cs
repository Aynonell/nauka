using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    class BubbleSort
    {
        public void Sort(Items toSort)
        {
            toSort.Sorted.Clear();
            toSort.Sorted.AddRange(toSort.Source);
            bool changed;
            int countSorted = 0;
            do
            {
                changed = false;
                for (int i = 0; i < toSort.Sorted.Count - countSorted - 1; i++)
                {
                    if (toSort.Sorted[i] > toSort.Sorted[i + 1])
                    {
                        swap(toSort, i);
                        changed = true;
                    }
                }
                countSorted++;
            } while (changed);
            toSort.isSorted = true;
            toSort.PrintSource();
            toSort.PrintSorted();
        }
        void swap(Items ToSort, int indexFirst)
        {
            double tmp = ToSort.Sorted[indexFirst];
            ToSort.Sorted[indexFirst] = ToSort.Sorted[indexFirst+1];
            ToSort.Sorted[indexFirst + 1] = tmp;
        }
        

    }
}

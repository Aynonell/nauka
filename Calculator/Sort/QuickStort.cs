using System;
using System.Collections.Generic;

namespace Sort
{
    public class QuickSort
    {
        public void Sort(Items toSort)
        {
            toSort.Sorted.Clear();
            toSort.Sorted.AddRange(toSort.Source);
            SortList(toSort.Sorted, 0, toSort.Sorted.Count - 1);
            toSort.isSorted = true;

        }
        void SortList(List<double> numbersToSort, int left, int right)
        {
            int leftIndex = left;
            int rightIndex = right;
            int pivotIndex = getPivotIndex(left, right);

            if (leftIndex < rightIndex)
            {                
                while (leftIndex != rightIndex)
                {
                    leftIndex = left;
                    rightIndex = right;
                    while (numbersToSort[leftIndex] < numbersToSort[pivotIndex])
                    {
                        leftIndex++;
                        if (leftIndex == pivotIndex)
                        {
                            break;
                        }
                    }
                    while (numbersToSort[rightIndex] >= numbersToSort[pivotIndex])
                    {
                        rightIndex--;
                        if (rightIndex == pivotIndex)
                        {
                            break;
                        }
                    }
                    if (numbersToSort[leftIndex] > numbersToSort[rightIndex])
                    {
                        double tmp = numbersToSort[leftIndex];
                        numbersToSort[leftIndex] = numbersToSort[rightIndex];
                        numbersToSort[rightIndex] = tmp;
                    }
                }
                SortList(numbersToSort, left, leftIndex - 1);
                SortList(numbersToSort, rightIndex + 1, right);
            }
        }
        private int getPivotIndex(int left, int right)
        {
            return left + (right - left) / 2;
        }
    }
}
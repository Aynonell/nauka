using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public class Items
    {
        public List<double> Source { get; set; }
        public List<double> Sorted { get; set; }
        public bool isSorted;
        public Items(int count = 10)
        {
            isSorted = false;
            if (count < 1)
            {
                count = 10;
            }
            Source = new List<double>();
            Sorted = new List<double>();
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                Source.Add(rnd.NextDouble() * 100);
            }
        }
        public void PrintSource()
        {
            foreach (var item in Source)
            {
                Console.Write("{0:0.00} ", item);
            }
            Console.WriteLine("\n");
        }
        public void PrintSorted()
        {
            if (isSorted)
            {
                foreach (var item in Sorted)
                {
                    Console.Write("{0:0.00} \n", item);
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Jeszcze nie posortowane");
            }
        }
    }

}

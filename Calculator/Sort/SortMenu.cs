using System;
using System.Collections.Generic;
using System.Text;
using Menus;

namespace Sort
{
    class SortMenu : Menu
    {

        //private Run RunProgram = new Run();
        public SortMenu()
        {
            ButtonList = new List<Button> {
                new Button(RunBubbleSort)
                {
                    Name = "Bubble Sort",
                    Description = "Sortowanie Bąbelkowe",
                    Enabled = true,
                    Active = true

                },
                new Button(RunQuickSort)
                {
                    Name = "Quick Sort",
                    Description = "Sortowanie algorytmem QuisckSort",
                    Enabled = true,
                    Active = false
                },
                new Button(RunBinaryTree)
                {
                    Name = "DrzewoBinarne",
                    Description = "Sortowanie z użyciem drzewa binarnego",
                    Enabled = true,
                    Active = false
                },
                new Button(RunSortByInsert)
                {
                    Name = "Insesrt Sort",
                    Description = "Sortowanie przez wstawiania",
                    Enabled = true,
                    Active = false

                },
            };
            //RunProgram.AddFunction(this);
            CurentActiveButton = 0;
        }

        public void RunBubbleSort()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.WriteLine("Podaj jak długi ma być ciąg liczb do posortowania?");
                bool isNumber;
                do
                {
                    String input = Console.ReadLine();
                    isNumber = int.TryParse(input, out int count);
                    if (isNumber)
                    {
                        Items toSort = new Items(count);

                        toSort.PrintSource();
                        BubbleSort bubble = new BubbleSort();
                        bubble.Sort(toSort);
                    }
                } while (!isNumber);

            }
            while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.Escape);
        }
        public void RunSortByInsert()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.WriteLine("Podaj jak długi ma być ciąg liczb do posortowania?");
                bool isNumber;
                do
                {
                    String input = Console.ReadLine();
                    isNumber = int.TryParse(input, out int count);
                    if (isNumber)
                    {
                        Items ToSort = new Items(count);

                        ToSort.PrintSource();
                        
                        SortByInsert sortByInsert = new SortByInsert();
                        sortByInsert.Sort(ToSort);
                        ToSort.PrintSorted();
                    }
                } while (!isNumber);

            }
            while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.Escape);
        }


        public void RunQuickSort()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.WriteLine("Quick Sort. \n ESC aby zakończyć");
                bool isNumber;
                do
                {
                    Console.WriteLine("Podaj jak długi ma być ciąg liczb do posortowania?");
                    String input = Console.ReadLine();
                    isNumber = int.TryParse(input, out int count);
                    if (isNumber)
                    {
                        Items toSort = new Items(count);
                        toSort.PrintSource();
                        QuickSort quickSort= new QuickSort();
                        quickSort.Sort(toSort);
                        toSort.PrintSorted();
                    }
                } while (!isNumber);
            }
            while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.Escape);
        }
        public void RunBinaryTree()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.WriteLine("Binary Tree. \n ESC aby zakończyć");
                bool isNumber;
                do
                {
                    Console.WriteLine("Podaj jak długi ma być ciąg liczb do posortowania?");
                    String input = Console.ReadLine();
                    isNumber = int.TryParse(input, out int count);
                    if (isNumber)
                    {
                        Items toSort = new Items(count);
                        toSort.PrintSource();
                        BinaryTree Tree = new BinaryTree(toSort);
                        toSort.PrintSorted();
                    }
                } while (!isNumber);
            }
            while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.Escape);
        }
    }
}
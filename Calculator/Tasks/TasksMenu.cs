using System;
using System.Collections.Generic;
using System.Text;
using Menus;
using Tasks.Task4;
using Tasks.Task5;
using Tasks.Task6;
using Tasks.Task7;

namespace Tasks
{
    class TasksMenu : Menu
    {

        //private Run RunProgram = new Run();
        public TasksMenu()
        {
            ButtonList = new List<Button> {
                
                new Button(RunSumLeafs)
                {
                    Name = "Task4",
                    Description = "Suma Liści",
                    Enabled = true,
                    Active = true

                },
                new Button(RunCheckSum)
                {
                    Name = "Task5",
                    Description = "Poszukiwanie Sumy",
                    Enabled = true,
                    Active = false

                },
                new Button(RunExelColumNumber)
                {
                    Name = "Task6",
                    Description = "Exel Colum Number",
                    Enabled = true,
                    Active = false

                },
                new Button(RunRomanToInt)
                {
                    Name = "Task7",
                    Description = "Roman to int",
                    Enabled = true,
                    Active = false

                },
            };
            CurentActiveButton = 0;
        }

        public void RunSumLeafs()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                int?[] root = new int?[] { 1, 2, 3, 4, 5, null, 6, 7, null, null, null, null, 8 };
                int?[] root2 = new int?[] { 1, 2, 3, 4, null, 6, 7, 8, 9, null, null, 12, 13, 14, null, 16, null, null, 19, null, null, null, 23, null, null, 26};
                Tree tree = new Tree(root);
                Console.WriteLine(tree.summary);
                tree = new Tree(root2);
                Console.WriteLine(tree.summary); ;
            }
            while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.Escape);
        }
        public void RunCheckSum()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.Clear();
                List<int> numbers = new List<int>();
                Sum Numbers = new Sum();
                Numbers.initList(numbers,15);
                StringBuilder line = new StringBuilder("-",10);
                Console.WriteLine(line);
                Console.WriteLine(Numbers.IsSumExist(numbers, 18));
                Console.WriteLine(Numbers.IsSumExistV3(numbers,18));
            }
            while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.Escape);
        }
        public void RunExelColumNumber()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.Clear();
                Task06 task6 = new Task06();
                Console.WriteLine($"F - {task6.TitleToNumber("F")}");
                Console.WriteLine($"AZ - {task6.TitleToNumber("AZ")}");
                Console.WriteLine($"AB - {task6.TitleToNumber("AB")}");
                Console.WriteLine($"AAA - {task6.TitleToNumber("AAA")}");
                Console.WriteLine($"KN - {task6.TitleToNumber("KN")}");
                Console.WriteLine($"WB - {task6.TitleToNumber("WB")}");
                Console.WriteLine($"ALL - {task6.TitleToNumber("ALL")}");
            }
            while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.Escape);
        }
        public void RunRomanToInt()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.Clear();
                Task07 task7 = new Task07();
                Console.WriteLine($"IV - {task7.RomanToInt ("IV")}");
                Console.WriteLine($"V - {task7.RomanToInt("V")}");
                Console.WriteLine($"XX - {task7.RomanToInt("XX")}");
                Console.WriteLine($"IX - {task7.RomanToInt("IX")}");
                Console.WriteLine($"XI - {task7.RomanToInt("XI")}");
                Console.WriteLine($"XL - {task7.RomanToInt("XL")}");
                Console.WriteLine($"M - {task7.RomanToInt("M")}");
                Console.WriteLine($"C - {task7.RomanToInt("C")}");
            }
            while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.Escape);
        }
    }
}
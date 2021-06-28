using System;
using System.Collections.Generic;
using System.Text;
using Calculator;
using Sort;
using Tasks;

namespace Application.menu
{
    public class Run
    {
        public void RunCalculator()
        {
            ConsoleKeyInfo consoleKeyInfo;

            Console.WriteLine("Witam - Potrfię: dodawać odejmować mnożyć i dzielić.");
            do
            {
                Console.WriteLine("Jakie działanie dla Ciebie rozwiazać?");
                var input = Console.ReadLine();
                Calc Expression = new Calc();
                try
                {
                    var result = Expression.GetExpression(input);
                    if (result.IsSuccess)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(result.Message);
                        Console.WriteLine($"Wynik: {result.calcResult}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Nacisnij ENTER aby obliczyć kolejne działanie. Naciśnij ESC aby wyjść do menu.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(result.Message);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Nacisnij ENTER aby obliczyć kolejne działanie. Naciśnij ESC aby wyjść do menu.");
                        Console.ResetColor();
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Błąd złapany poza walidacją: {e.Message}");
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine($"Błąd złapany poza walidacją: {e.Message}");
                }
            } while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.Escape);
        }
        public void RunSnake()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.WriteLine("Uruchamianie Snake");
            }
            while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.Escape);
        }
        public void RunSettings()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.WriteLine("Uruchamianie Ustawienia. \n ESC aby zakończyć");

            }
            while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.Escape);
        }
        public void RunSortMenu()
        {
            ProgramSort.start();
        }

        public void RunTasksMenu()
        {
            ProgramTasks.start();  
        }

        public void RunExit()
        {
            Environment.Exit(0);
        }

    }
}


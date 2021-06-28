using System;
using System.Collections.Generic;
using System.Text;

namespace Menus
{
    public class Button
    {
        public string Name { get; set; } // or label
        public string Description { get; set; } // for mouse over  :D
        public bool Active { get; set; }
        public bool Enabled { get; set; }
        

        public delegate void RunOnEvent();
        public event RunOnEvent RunProgram;

        ConsoleColor ActiveColor = ConsoleColor.Cyan;
        ConsoleColor InactiveColor = ConsoleColor.White;
        ConsoleColor DisabledColor = ConsoleColor.DarkGray;
        ConsoleColor MainColor = ConsoleColor.DarkGreen;
        public Button()
        {
            //this button do nothing // 
            Enabled = false;
        }
        public Button(RunOnEvent func)
        {
            RunProgram = func;
        }
        public void PrintFirstButton(int width = 0)
        {
            Console.ForegroundColor = MainColor;
            if (width == 0)
            {
                width = Name.Length;
            }
            if (width > 0)
            {
                printBar(width);
                printNameButton(width);
                Console.WriteLine();
                printBar(width);
            }
            else
            {
                throw new Exception("Nie poprawna długość przycisku");
            }
        }

        public void PrintMiddleButton(int width = 0)
        {
            Console.ForegroundColor = MainColor;
            if (width == 0 || width < Name.Length)
            {
                width = Name.Length;
            }
            if (width > 0)
            {
                printNameButton(width);
                Console.WriteLine();
                printBar(width);
            }
            else
            {
                throw new Exception("Nie poprawna długość przycisku");
            }
        }
        private void printBar(int width)
        {
            Console.Write("+");
            for (int i = 0; i < width + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.WriteLine();
        }
        private void printNameButton(int width)
        {

            Console.Write($"| ");
            if (Active == true)
            {
                Console.ForegroundColor = ActiveColor;
            }
            if (Active == false)
            {
                Console.ForegroundColor = InactiveColor;
            }
            if (Enabled == false)
            {
                Console.ForegroundColor = DisabledColor;
            }

            if (Name.Length == width)
            {
                Console.Write(Name);
            }
            else
            {
                int spaces = width - Name.Length;
                Console.Write(Name);
                for (int z = 0; z < spaces; z++)
                {
                    Console.Write(" ");
                }
            }
            Console.ForegroundColor = MainColor;
            Console.Write(" |");
        }

        public void SetActive()
        {
            Active = true;
        }
        public void SetInactive()
        {
            Active = false;
        }
        public void OnClic()
        {
            //if (RunProgram != null)
            //{
            //    RunProgram();
            //}
            // to samo ponizej a ladniej :D
            RunProgram?.Invoke();
        }
        
    }
}

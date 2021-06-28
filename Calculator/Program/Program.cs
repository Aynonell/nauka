using Calculator.menu;
using System;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            ProjectMenu MineMenu = new ProjectMenu() { };
            //Button testButton = new Button() { Name = "Test", Description = "Nacisnij mnie", Enabled = true, Active = false };
            MineMenu.runMenu();
            Console.Clear();
            string anoucemenet = "Do zobaczenia wkrótce!";
            Console.SetCursorPosition(Console.WindowWidth/2-anoucemenet.Length/2, 0);
            Console.WriteLine(anoucemenet);
        }
    }
}


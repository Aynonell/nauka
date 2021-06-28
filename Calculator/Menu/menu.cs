using System;
using System.Collections.Generic;

namespace Menus
{
    public class Menu
    {
        public List<Button> ButtonList { get; set; }
        public EnumStateMenu State;
        public int CurentActiveButton = 0;
        public ConsoleColor DescriptionColor = ConsoleColor.Yellow;

        public Menu()
        {
            ButtonList = new List<Button>
            {
                new Button(RunSomething) {
                    Name = "ActionButton",
                    Description = "Jeśli widzisz ten przycisk - popraw konstruktor swojej klasy \n Przykladowe wywolanie funkcji",
                    Enabled = true,
                    Active = false,
                }
            };

            CurentActiveButton = 0;
        }
        public void PrintButtons()
        {
            // find the longest name on button.
            var width = CalculateWidthMenu();
            if (ButtonList.Count > 0)
            {
                ButtonList[0].PrintFirstButton(width);
            }
            if (ButtonList.Count > 1)
            {
                for (int i = 1; i < ButtonList.Count; i++)
                {
                    ButtonList[i].PrintMiddleButton(width);
                }
            }
        }
        public void PrintButtonsAndDescriptions()
        {
            PrintButtons();
            int indexActiveButton = FindActiveButton();
            if (indexActiveButton != -1)
            {
                State = EnumStateMenu.visible;
                Console.ForegroundColor = DescriptionColor;
                Console.WriteLine(ButtonList[indexActiveButton].Description);
                Console.ResetColor();
            }
        }
        private int CalculateWidthMenu()
        {
            int max = 0;
            for (int i = 0; i < ButtonList.Count; i++)
            {
                if (ButtonList[i].Name.Length > max)
                {
                    max = ButtonList[i].Name.Length;
                }
            }
            return max;
        }
        private int FindActiveButton()
        {
            var index = ButtonList.FindIndex(x => x.Active == true);
            return index;
        }
        public void DownActive()
        {
            if (State == EnumStateMenu.visible)
            {
                for (int i = CurentActiveButton + 1; i < ButtonList.Count; i++)
                {
                    if (ButtonList[i].Enabled)
                    {
                        ButtonList[CurentActiveButton].Active = false;
                        ButtonList[i].Active = true;
                        CurentActiveButton = i;
                        break;
                    }
                }

            }

        }
        public void UpActive()
        {
            if (State == EnumStateMenu.visible)
            {
                for (int i = CurentActiveButton - 1; i >= 0; i--)
                {
                    if (ButtonList[i].Enabled)
                    {
                        ButtonList[CurentActiveButton].Active = false;
                        ButtonList[i].Active = true;
                        CurentActiveButton = i;
                        break;
                    }
                }

            }
        }


        public void runMenu()
        {

            PrintButtonsAndDescriptions();
            ConsoleKeyInfo consoleKeyInfo;
            bool stopMenu = false;
            while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.Escape || stopMenu == true)
            {
                if (consoleKeyInfo.Key == ConsoleKey.DownArrow && State == EnumStateMenu.visible)
                {
                    DownActive();
                    Console.Clear();
                    PrintButtonsAndDescriptions();
                }
                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                {
                    State = EnumStateMenu.visible;
                    Console.Clear();
                    PrintButtonsAndDescriptions();
                }
                if (consoleKeyInfo.Key == ConsoleKey.UpArrow && State == EnumStateMenu.visible)
                {
                    UpActive();
                    Console.Clear();
                    PrintButtonsAndDescriptions();
                }
                if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {

                    State = EnumStateMenu.hidden;
                    Console.Clear();
                    ButtonList[CurentActiveButton].OnClic();
                    Console.Clear();
                    PrintButtonsAndDescriptions();
                }
            }
        }
        public void RunSomething()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.WriteLine("Przykladowe wywolanie funkcji \n ESC aby zakończyć");
            }
            while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.Escape);
        }
    }
}

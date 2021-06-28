using System.Collections.Generic;
using Menus;

namespace MyProgram
{
    public class ProjectMenu : Menu
    {
        private Run RunProgram = new Run();
        public ProjectMenu()
        {
            ButtonList = new List<Button> {
                new Button(RunProgram.RunCalculator)
                {
                    Name = "Kalkulator",
                    Description = "Chcesz coś policzyć? ",
                    Enabled = true,
                    Active = true,
                    Action = EnumActions.calculator
                },
                new Button(RunProgram.RunSnake)
                {
                    Name = "Gra - Snake",
                    Description = "Chwila relaksu?",
                    Enabled = true,
                    Active = false,
                    Action = EnumActions.snake
                },
                new Button(RunProgram.RunSettings)
                {
                    Name = "Ustawienia",
                    Description = "Coś ci się nie podoba?",
                    Enabled = true,
                    Active = false,
                    Action = EnumActions.settings
                },
                new Button(RunProgram.RunSortMenu)
                {
                    Name = "Sortowanie",
                    Description = "Posortuj ciąg znaków",
                    Enabled = false,
                    Active = false,
                    Action = EnumActions.sort,
                },
                new Button(RunProgram.RunExit)
                {
                    Name="Exit",
                    Description="Na prawdę ? :( ",
                    Enabled = false,
                    Active = false ,
                    Action = EnumActions.exit
                }
            };
            CurentActiveButton = 0;
        }
    }
}

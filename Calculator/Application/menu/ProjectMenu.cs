using System;
using System.Collections.Generic;
using Menus;

namespace Application.menu
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
                    Active = true
                    
                },
                new Button(RunProgram.RunSnake)
                {
                    Name = "Gra - Snake",
                    Description = "Chwila relaksu?",
                    Enabled = true,
                    Active = false
                    
                },
                new Button(RunProgram.RunSettings)
                {
                    Name = "Ustawienia",
                    Description = "Coś ci się nie podoba?",
                    Enabled = true,
                    Active = false
                   
                },
                new Button(RunProgram.RunSortMenu)
                {
                    Name = "Sortowanie",
                    Description = "Posortuj ciąg znaków",
                    Enabled = true,
                    Active = false
                   
                },
                new Button(RunProgram.RunTasksMenu)
                {
                    Name = "Zadania",
                    Description = "Różne zadanka",
                    Enabled = true,
                    Active = false

                },
                new Button(RunProgram.RunExit)
                {
                    Name="Exit",
                    Description="Na prawdę ? :( ",
                    Enabled = true,
                    Active = false
                   
                }
                
            };
            CurentActiveButton = 0;

        }

    }
}

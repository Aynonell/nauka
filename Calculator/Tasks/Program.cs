using System;

namespace Tasks
{
    public class ProgramTasks
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadania na Interviev");
            TasksMenu menu = new TasksMenu();
            menu.runMenu();
        }
        public static void start()
        {
            TasksMenu menu = new TasksMenu();
            menu.runMenu();
        }
    }
}

using System;

namespace HomeWork_07
{
    class Program
    {
        private static void Main()
        {
            const string path = "note.csv";

            Diary repOne = new(path);

            repOne.PrintToConsole();

            Print.Text("Finish", ConsoleColor.DarkGreen);

            Console.ReadKey();
        }
    }
}

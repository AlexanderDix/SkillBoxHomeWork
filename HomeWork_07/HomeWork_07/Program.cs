using System;

namespace HomeWork_07
{
    class Program
    {
        static void Main()
        {
            string path = "note.csv";
            string pathTest = "note.diary";

            Repository repOne = new(path);
            Repository repTwo = new(pathTest);

            repOne.PrintToConsole();

            Print.Text("Finish", ConsoleColor.DarkGreen);

            Console.ReadKey();
        }
    }
}

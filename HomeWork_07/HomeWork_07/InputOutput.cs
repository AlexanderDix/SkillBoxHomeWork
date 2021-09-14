using System;

namespace HomeWork_07
{
    class InputOutput
    {
        public static void Text(string text)
        {
            Console.WriteLine(text);
        }

        public static void Text(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static string Input(string header)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{header}");
            Console.ResetColor();

            return Console.ReadLine();
        }

        public static int CheckInput()
        {
            while (true)
            {
                var input = Console.ReadLine();
                var checkInput = int.TryParse(input, out var number);

                if (checkInput && number >= 0) return number;

                Text("Данные введены некорректно", ConsoleColor.DarkRed);
            }
        }
    }
}

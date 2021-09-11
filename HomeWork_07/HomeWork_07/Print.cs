using System;

namespace HomeWork_07
{
    struct Print
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
    }
}

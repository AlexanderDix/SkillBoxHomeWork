using System;
using System.Runtime.CompilerServices;

namespace HomeWork_08
{
    class InOut
    {
        /// <summary>
        /// Вывод текста на консоль
        /// </summary>
        /// <param name="text">Текст</param>
        public static void Print(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Вывод текста на консоль в определенном цвете
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="color">Цвет текста</param>
        public static void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Проверка ввода пользователя на число
        /// </summary>
        /// <returns>Возвращает число</returns>
        public static int InputInt()
        {
            while (true)
            {
                var input = Console.ReadLine();
                var check = int.TryParse(input, out var number);

                if (check && number > 0) return number;

                Print("Данные введены некорректно", ConsoleColor.DarkRed);
            }
        }

        /// <summary>
        /// Просим пользователя ввести данные
        /// </summary>
        /// <param name="header">Загаловок</param>
        /// <returns>Возвращаем число</returns>
        public static int InputInt(string header)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{header}:");
            Console.ResetColor();

            return InputInt();
        }

        /// <summary>
        /// Просим ввести данные
        /// </summary>
        /// <param name="header">Загаловок</param>
        /// <returns>Возвращаем строку</returns>
        public static string InputStr(string header)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{header}:");
            Console.ResetColor();

            return InputStr();
        }

        /// <summary>
        /// Просим ввести и проверяем ввод пользователя на пустую строку или пробел в строке
        /// </summary>
        /// <returns>Возвращаем строку</returns>
        public static string InputStr()
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input)) return input;

                Print("Данные введены некорректно", ConsoleColor.DarkRed);
            }
        }
    }
}

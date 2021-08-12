using System;

namespace HomeWork_05
{
    /// <summary>
    /// Класс вывода текста на консоль
    /// </summary>
    class Print
    {
        /// <summary>
        /// Вывод пустой строки
        /// </summary>
        public static void Text()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Вывод текста на консоль
        /// </summary>
        /// <param name="text">Текст, который нужно вывести</param>
        public static void Text(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Вывод цветного текста на консоль
        /// </summary>
        /// <param name="text">Текст, который нужно вывести</param>
        /// <param name="color">Цвет выводимого текста</param>
        public static void Text(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Вывод текста без переноса на новую строку
        /// </summary>
        /// <param name="text">Текст, который нужно вывести</param>
        public static void NoEnterText(string text)
        {
            Console.Write(text);
        }

        /// <summary>
        /// Вывод цветного текста без переноса на новую строку
        /// </summary>
        /// <param name="text">Текст, который нужно вывести</param>
        /// <param name="color">Цвет выводимого текста</param>
        public static void NoEnterText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
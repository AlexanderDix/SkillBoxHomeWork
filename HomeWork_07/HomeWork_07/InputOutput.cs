using System;

namespace HomeWork_07
{
    class InputOutput
    {
        /// <summary>
        /// Вывод текста на консоль
        /// </summary>
        /// <param name="text"></param>
        public static void Text(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Выводим цветной текст на консоль
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="color">Цвет текста</param>
        public static void Text(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Просим пользователя ввести данные
        /// </summary>
        /// <param name="header">Заголовок</param>
        /// <returns>Возвращаем введенную строку</returns>
        public static string Input(string header)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{header}");
            Console.ResetColor();

            return Console.ReadLine();
        }

        /// <summary>
        /// Проверка ввода пользователя
        /// </summary>
        /// <returns>Возвращаем число введенное пользователем</returns>
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

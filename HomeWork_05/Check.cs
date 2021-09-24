using System;

namespace HomeWork_05
{
    /// <summary>
    /// Класс проверки ввода пользователя
    /// </summary>
    class Check
    {
        /// <summary>
        /// Проверяем пользовательский ввод
        /// </summary>
        /// <returns>Возвращаем число</returns>
        public static int InputUser()
        {
            while (true)
            {
                var input = Console.ReadLine();
                var checkInput = int.TryParse(input, out var number);

                if (!checkInput || number < 0)
                {
                    Print.Text("Данные введены некорректно", ConsoleColor.DarkRed);
                    continue;
                }

                return number;
            }
        }

        /// <summary>
        /// Проверка введеных данных пользователя для типа double
        /// </summary>
        /// <returns>Возвращаем число</returns>
        public static double InputDouble()
        {
            while (true)
            {
                var input = Console.ReadLine();
                var checkInput = double.TryParse(input, out var number);

                if (!checkInput || number < 0)
                {
                    Print.Text("Данные введены некорректно", ConsoleColor.DarkRed);
                    continue;
                }

                return number;
            }
        }

        /// <summary>
        /// Проверяем введенные данные на пустую строку
        /// </summary>
        /// <returns>Возвращаем введенную строку</returns>
        public static string Input()
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(input))
                {
                    Print.Text("Данные введены некорректно", ConsoleColor.DarkRed);
                    continue;
                }

                return input;
            }
        }
    }
}
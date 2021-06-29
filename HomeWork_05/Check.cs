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
            var input = Console.ReadLine();
            var checkInput = int.TryParse(input, out var number);

            while (!checkInput || number < 0)
            {
                Print.Text("Данные введены некорректно", ConsoleColor.DarkRed);
                break;
            }

            return number;
        }
    }
}
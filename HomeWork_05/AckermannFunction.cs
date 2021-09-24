using System;
using System.Collections.Generic;

namespace HomeWork_05
{
    public class AckermannFunction
    {
        /// <summary>
        /// Основная логика класса, просим пользователя ввести числа и вывод результата
        /// </summary>
        public static void MainLogic()
        {
            Print.Text("Введите значения m и n", ConsoleColor.DarkCyan);

            Print.NoEnterText("m = ");
            var m = Check.InputUser();

            Print.NoEnterText("n = ");
            var n = Check.InputUser();

            Print.Text($"Результат функции Аккермана с рекурсией: {AckermannFuncRecursive(m, n)} \n" +
                       $"Результат функции Аккермана без рекурсии: {AckermannFuncNonRecursive(m, n)}");

            Program.BackChoice();
            Program.ChoiceProgram();
        }

        /// <summary>
        /// Вычисление функции Аккермана с помощью рекурсии
        /// </summary>
        /// <param name="m">Первое число</param>
        /// <param name="n">Второе число</param>
        /// <returns>Возвращает результат функции Аккермана</returns>
        public static int AckermannFuncRecursive(int m, int n)
        {
            if (m == 0)
            {
                return n + 1;
            }
            if (n == 0)
            {
                return AckermannFuncRecursive(m - 1, 1);
            }

            return AckermannFuncRecursive(m - 1, AckermannFuncRecursive(m, n - 1));
        }

        /// <summary>
        /// Вычисление функции Аккермана без рекурсии
        /// </summary>
        /// <param name="m">Первое число</param>
        /// <param name="n">Второе число</param>
        /// <returns>Возвращает результат функции Аккермана</returns>
        public static int AckermannFuncNonRecursive(int m, int n)
        {
            Stack<int> result = new Stack<int>();

            result.Push(m);

            while (result.Count > 0)
            {
                m = result.Pop();
                if (m == 0)
                {
                    n++;
                }
                else if (n == 0)
                {
                    result.Push(--m);
                    n = 1;
                }
                else
                {
                    result.Push(--m);
                    result.Push(++m);
                    n--;
                }
            }

            return n;
        }
    }
}
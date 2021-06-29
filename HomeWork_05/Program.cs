using System;

namespace HomeWork_05
{
    class Program
    {
        private static void Main()
        {
            CalculationMatrices.SelectingActionWithMatrix();
        }

        public static void BackChoice()
        {
            Print.Text("Нажмите кнопку чтобы вернуться к меню выбора действий...", ConsoleColor.DarkCyan);

            Console.ReadKey();

            Console.Clear();
        }
    }
}

using System;

namespace HomeWork_05
{
    class Program
    {
        private static void Main()
        {
            ChoiceProgram();
        }

        /// <summary>
        /// Реализация заглушки после выполнения программы
        /// </summary>
        public static void BackChoice()
        {
            Print.Text("Нажмите кнопку чтобы вернуться к меню выбора действий...", ConsoleColor.DarkCyan);

            Console.ReadKey();

            Console.Clear();
        }

        public static void ChoiceProgram()
        {
            while (true)
            {
                var programOne = "1 - Программа по работе с матрицами \n";
                var programTwo = "2 - Программа по работе с текстом \n";
                var programThree = "3 - Программа по работе с прогрессиями \n";
                var programFour = "4 - Программа по работе с функцией Аккермана \n";
                var programExit = "5 - Завершить работу";

                var printText = $" {programOne} {programTwo} {programThree} {programFour} {programExit}";

                Print.Text("Выберите программу: ", ConsoleColor.DarkCyan);
                Print.Text(printText);

                var input = Check.InputUser();

                switch (input)
                {
                    case 1:
                        CalculationMatrices.SelectingActionWithMatrix();
                        break;
                    case 2:
                        WorkingWithText.ChoiceProgram();
                        break;
                    case 3:
                        Progression.MainLogic();
                        break;
                    case 4:
                        AckermannFunction.MainLogic();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Print.Text("Такого пункта нет", ConsoleColor.DarkRed);
                        continue;
                }
                break;
            }
        }
    }
}

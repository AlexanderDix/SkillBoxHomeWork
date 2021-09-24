using System;

namespace HomeWork_08
{
    class Menu
    {
        /// <summary>
        /// Кортеж, хранящий номер действия и номер цели
        /// </summary>
        private static (int menuNumber, int target) _choiceTuple;

        /// <summary>
        /// Просим пользователя выбрать действие
        /// </summary>
        public static void Choice()
        {
            const string menu = " 1 - Добавить\n" +
                                " 2 - Редактировать\n" +
                                " 3 - Удалить\n" +
                                " 4 - Сортировка\n" +
                                " 5 - Вывести на экран\n" +
                                " 6 - Выход";

            InOut.Print("Выберите действие", ConsoleColor.DarkCyan);
            InOut.Print(menu);

            while (true)
            {
                var input = InOut.InputInt();

                switch (input)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        ChoiceTarget(input);
                        RunChoice();
                        break;
                    case 5:
                        ChoiceTarget();
                        RunChoice();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        InOut.Print("Такого пункта нет", ConsoleColor.DarkRed);
                        continue;
                }
                break;
            }
        }

        /// <summary>
        /// Просим пользователя выбрать цель для действия
        /// </summary>
        /// <param name="menuNumber">Номер действия</param>
        public static void ChoiceTarget(int menuNumber)
        {
            const string targets = "    1 - Сотрудник\n" +
                                   "    2 - Департамент\n" +
                                   "    3 - Назад";

            InOut.Print("  Выберите цель:", ConsoleColor.DarkCyan);
            InOut.Print(targets);

            while (true)
            {
                var input = InOut.InputInt();

                switch (input)
                {
                    case 1:
                    case 2:
                        _choiceTuple = (menuNumber, input);
                        break;
                    case 3:
                        Console.Clear();
                        Choice();
                        break;
                    default:
                        InOut.Print("Такого пункта нет", ConsoleColor.DarkRed);
                        continue;
                }
                break;
            }
        }

        /// <summary>
        /// Просим пользователя выбрать цель для действия (для пункта 5)
        /// </summary>
        public static void ChoiceTarget()
        {
            const string targets = "    1 - Сотрудник\n" +
                                   "    2 - Департамент\n" +
                                   "    3 - Компания\n" +
                                   "    4 - Назад";

            InOut.Print("  Выберите цель:", ConsoleColor.DarkCyan);
            InOut.Print(targets);

            while (true)
            {
                var input = InOut.InputInt();

                switch (input)
                {
                    case 1:
                    case 2:
                    case 3:
                        _choiceTuple = (5, input);
                        break;
                    case 4:
                        Console.Clear();
                        Choice();
                        break;
                    default:
                        InOut.Print("Такого пункта нет", ConsoleColor.DarkRed);
                        continue;
                }
                break;
            }
        }

        /// <summary>
        /// Запуск действий для заданной цели
        /// </summary>
        public static void RunChoice()
        {
            while (true)
            {
                switch (_choiceTuple)
                {
                    case (menuNumber: 1, target: 1):
                        MainLogic.AddEmployee();
                        ClearAndBack();
                        break;
                    case (menuNumber: 1, target: 2):
                        MainLogic.AddDepartament();
                        ClearAndBack();
                        break;
                    case (menuNumber: 2, target: 1):
                        MainLogic.EditEmployee();
                        ClearAndBack();
                        break;
                    case (menuNumber: 2, target: 2):
                        MainLogic.EditDepartament();
                        ClearAndBack();
                        break;
                    case (menuNumber: 3, target: 1):
                        MainLogic.DeleteEmployee();
                        ClearAndBack();
                        break;
                    case (menuNumber: 3, target: 2):
                        MainLogic.DeleteDepartament();
                        ClearAndBack();
                        break;
                    case (menuNumber: 4, target: 1):
                        MainLogic.SortEmployee();
                        ClearAndBack();
                        break;
                    case (menuNumber: 4, target: 2):
                        MainLogic.SortDepartament();
                        ClearAndBack();
                        break;
                    case (menuNumber: 5, target: 1):
                        MainLogic.PrintEmployee();
                        ClearAndBack();
                        break;
                    case (menuNumber: 5, target: 2):
                        MainLogic.PrintDepartament();
                        ClearAndBack();
                        break;
                    case (menuNumber: 5, target: 3):
                        MainLogic.PrintCompany();
                        ClearAndBack();
                        break;
                }
                break;
            }
        }

        #region Private methods

        /// <summary>
        /// Очитска консоли и возврат к меню выбора
        /// </summary>
        private static void ClearAndBack()
        {
            Console.Clear();

            Choice();
        }

        #endregion
    }
}

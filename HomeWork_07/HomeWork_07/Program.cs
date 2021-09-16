using System;

namespace HomeWork_07
{
    class Program
    {
        private static void Main()
        {
            ChoiceMenu();
        }

        private static void ChoiceMenu()
        {
            const string choiceOne = " 1 - Добавление записи\n";
            const string choiceSecond = " 2 - Редактирование записи\n";
            const string choiceThree = " 3 - Удаление записи\n";
            const string choiceFour = " 4 - Вывод записей на экран\n";
            const string choiceFive = " 5 - Вывод записей, сортированных по определенному полю\n";
            const string choiceSix = " 6 - Вывод записей по заданной дате\n";
            const string exit = " 7 - Выход";

            var pattern = $"{choiceOne}" +
                                $"{choiceSecond}" +
                                $"{choiceThree}" +
                                $"{choiceFour}" +
                                $"{choiceFive}" +
                                $"{choiceSix}" +
                                $"{exit}";

            InputOutput.Text("Выберите нужное действие", ConsoleColor.DarkCyan);
            InputOutput.Text(pattern);

            RunChoice();
        }

        private static void RunChoice()
        {
            var choiceNumber = InputOutput.CheckInput();

            while (true)
            {
                switch (choiceNumber)
                {
                    case 1:
                        MainLogic.AddNotes();
                        ChoiceMenu();
                        break;
                    case 2:
                        MainLogic.EditNotes();
                        ChoiceMenu();
                        break;
                    case 3:
                        MainLogic.DeleteNotes();
                        ChoiceMenu();
                        break;
                    case 4:
                        MainLogic.PrintNotes();
                        ChoiceMenu();
                        break;
                    case 5:
                        MainLogic.PrintNotesAfterSort();
                        ChoiceMenu();
                        break;
                    case 6:
                        MainLogic.PrintByDate();
                        ChoiceMenu();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        InputOutput.Text("Такого пункта нет", ConsoleColor.DarkRed);
                        continue;
                }

                break;
            }
        }
    }
}

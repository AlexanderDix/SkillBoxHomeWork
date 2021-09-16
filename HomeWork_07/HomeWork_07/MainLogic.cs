using System;

namespace HomeWork_07
{
    /// <summary>
    /// Основная логика
    /// </summary>
    class MainLogic
    {
        private const string Path = "diary.csv";

        private static readonly Diary Diary = new(Path);

        /// <summary>
        /// Добавление новой записи
        /// </summary>
        public static void AddNotes()
        {
            InputOutput.Text("Новая запись", ConsoleColor.DarkGreen);

            Diary.AddNote(InputNotes());

            SaveDiary();

            OutputStub();
        }

        /// <summary>
        /// Удаление записи по номеру
        /// </summary>
        public static void DeleteNotes()
        {
            PrintNotes();

            InputOutput.Text("Удалять записи по: \n" +
                             " 1 - Номеру записи" +
                             " 2 - Полю записи");

            switch (InputOutput.CheckInput())
            {
                case 1:
                    InputOutput.Text("Введите номер записи, которую хотите удалить", ConsoleColor.DarkCyan);
                    var indexNote = InputOutput.CheckInput();
                    Diary.DeleteNote(number:1, indexNote);
                    break;
                case 2:
                    DeleteByField();
                    break;
            }

            SaveDiary();

            OutputStub();
        }

        /// <summary>
        /// Редактирование записи по номеру
        /// </summary>
        public static void EditNotes()
        {
            PrintNotes();

            InputOutput.Text("Введите номер записи, которую хотите редактировать", ConsoleColor.DarkGreen);
            var indexNote = InputOutput.CheckInput();

            InputOutput.Text("Введите новые данные для записи");

            Diary.EditNote(indexNote, InputNotes());

            SaveDiary();

            OutputStub();
        }

        /// <summary>
        /// Вывод записей на консоль
        /// </summary>
        public static void PrintNotes()
        {
            InputOutput.Text("Записи в дневнике", ConsoleColor.DarkCyan);

            Diary.PrintToConsole();
        }

        /// <summary>
        /// Вывод на консоль по выбранной дате
        /// </summary>
        public static void PrintByDate()
        {
            InputOutput.Text("Выберите дату по которой необходимо вывести записи", ConsoleColor.DarkCyan);
            Diary.PrintDatesToConsole();

            var index = InputOutput.CheckInput();

            Diary.FindDate(index);

            OutputStub();
        }

        /// <summary>
        /// Вывод на консоль после сортировки по заданному полю
        /// </summary>
        public static void PrintNotesAfterSort()
        {
            InputOutput.Text("Выберите по какому полю сортировать", ConsoleColor.DarkCyan);
            Diary.SortNotes(ChoiceField());

            PrintNotes();

            OutputStub();
        }

        #region Private methods

        /// <summary>
        /// Сохранение записей
        /// </summary>
        private static void SaveDiary()
        {
            Diary.Save(Path);

            InputOutput.Text("Сохранение успешно", ConsoleColor.DarkGreen);
        }

        /// <summary>
        /// Просим пользователя ввести данные записи
        /// </summary>
        /// <returns>Возвращаем запись</returns>
        private static Note InputNotes()
        {
            var title = InputOutput.Input("Title");
            var author = InputOutput.Input("Author");
            var dateTime = DateTime.Now;
            var content = InputOutput.Input("Content");
            var importance = InputOutput.Input("Importance");

            return new Note(title, author, dateTime, content, importance);
        }

        /// <summary>
        /// Просим пользователя выбрать поле
        /// </summary>
        /// <returns>Возвращаем число</returns>
        private static int ChoiceField()
        {
            const string title = " 1 - Заголовок\n";
            const string author = " 2 - Автор\n";
            const string date = " 3 - Дата создания\n";
            const string content = " 4 - Контент\n";
            const string importance = " 5 - Важность";

            var pattern = $"{title}" +
                          $"{author}" +
                          $"{date}" +
                          $"{content}" +
                          $"{importance}";

            InputOutput.Text(pattern);

            var number = InputOutput.CheckInput();

            while (true)
            {
                switch (number)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        return number;
                    default:
                        InputOutput.Text("Такого поля нет", ConsoleColor.DarkRed);
                        continue;
                }
            }
        }

        /// <summary>
        /// Заглушка и очистка консоли после выполнения методов
        /// </summary>
        private static void OutputStub()
        {
            InputOutput.Text("Для продолжения работы нажмите любую кнопку...", ConsoleColor.DarkCyan);

            Console.ReadKey();

            Console.Clear();
        }

        /// <summary>
        /// Удаление записи по выбранному полю
        /// </summary>
        private static void DeleteByField()
        {
            InputOutput.Text("Выберите поле", ConsoleColor.DarkCyan);
            var number = ChoiceField();

            if (number == 3)
            {
                InputOutput.Text("Выберите дату по которой необходимо вывести записи", ConsoleColor.DarkCyan);
                Diary.PrintDatesToConsole();
                var index = InputOutput.CheckInput();

                Diary.DeleteNote(number, index);
            }
            else
            {
                InputOutput.Text("Введите текст", ConsoleColor.DarkCyan);
                var input = InputOutput.Input();

                Diary.DeleteNote(number, text: input);
            }
        }

        #endregion
    }
}
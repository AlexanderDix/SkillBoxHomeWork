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

            Diary.AddNote(InputNote());
        }

        /// <summary>
        /// Удаление записи по номеру
        /// </summary>
        public static void DeleteNotes()
        {
            InputOutput.Text("Введите номер записи, которую хотите удалить", ConsoleColor.DarkGreen);
            var indexNote = InputOutput.CheckInput();

            Diary.DeleteNote(indexNote);

            Diary.Save(Path);
        }

        /// <summary>
        /// Редактирование записи по номеру
        /// </summary>
        public static void EditNotes()
        {
            InputOutput.Text("Введите номер записи, которую хотите редактировать", ConsoleColor.DarkGreen);
            var indexNote = InputOutput.CheckInput();

            InputOutput.Text("Введите новые данные для записи");

            Diary.EditNote(indexNote, InputNote());

            Diary.Save(Path);
        }

        /// <summary>
        /// Просим пользователя ввести данные записи
        /// </summary>
        /// <returns>Возвращаем запись</returns>
        private static Note InputNote()
        {
            var title = InputOutput.Input("Title");
            var author = InputOutput.Input("Author");
            var dateTime = DateTime.Now;
            var content = InputOutput.Input("Content");
            var importance = InputOutput.Input("Importance");

            return new Note(title, author, dateTime, content, importance);
        }
    }
}
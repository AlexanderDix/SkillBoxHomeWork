using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork_07
{
    class Diary
    {
        #region Fields

        /// <summary>
        /// Коллекция хранящяя записи
        /// </summary>
        private List<Note> _notes;

        /// <summary>
        /// Массив хранящий заголовки
        /// </summary>
        private string[] _titles;

        /// <summary>
        /// Название файла из которого берутся данные
        /// </summary>
        private readonly string _path;

        /// <summary>
        /// Номер элемента в массиве notes
        /// </summary>
        private int _index;

        #endregion Fields

        #region Constructors

        public Diary(string path)
        {
            _path = path;
            _index = 0;
            _titles = Array.Empty<string>();
            _notes = new List<Note>();

            Load();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Проверка существования файла
        /// </summary>
        private void FileExists()
        {
            if (File.Exists(_path)) return;
            InputOutput.Text($"Файла {_path} не существует. Создание файла.", ConsoleColor.DarkRed);

            using StreamWriter sWriter = new(new FileStream(_path, FileMode.Create, FileAccess.Write));
            const string temp = "Title,Author,DateCreate,Content,Importance";

            sWriter.WriteLine(temp);
        }

        /// <summary>
        /// Загрузка данных из файла
        /// </summary>
        private void Load()
        {
            FileExists();

            using StreamReader sReader = new(_path);
            _titles = sReader.ReadLine().Split(',');

            while (!sReader.EndOfStream)
            {
                var data = sReader.ReadLine().Split(',');

                AddNote(new Note(
                    data[1],
                    data[2],
                    Convert.ToDateTime(data[3]),
                    data[4],
                    data[5]));
            }
        }

        /// <summary>
        /// Сохранение записи
        /// </summary>
        /// <param name="path">Путь</param>
        public void Save(string path)
        {
            File.Delete(path);

            var temp = $"{_titles[0]},{_titles[1]},{_titles[2]},{_titles[3]},{_titles[4]}";

            File.AppendAllText(path, $"{temp}\n");

            for (var i = 0; i < _index; i++)
            {
                temp =
                    $"{_notes[i].Title}," +
                    $"{_notes[i].Author}," +
                    $"{_notes[i].DateCreate.ToShortDateString()}," +
                    $"{_notes[i].Content}," +
                    $"{_notes[i].Importance}";

                File.AppendAllText(path, $"{temp}\n");
            }
        }

        #region Добавление записи

        /// <summary>
        /// Добавление записи в коллекцию при выгрузки из файла
        /// </summary>
        /// <param name="note">Запись</param>
        public void AddNote(Note note)
        {
            _notes.Add(note);
            _index++;
        }

        #endregion

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="indexNote">Индекс записи</param>
        public void DeleteNote(int indexNote)
        {
            _notes.RemoveAt(indexNote);
            _index--;
        }

        /// <summary>
        /// Редактирование записей
        /// </summary>
        /// <param name="indexNote">Индекс</param>
        /// <param name="note">Запись</param>
        public void EditNote(int indexNote, Note note)
        {
            _notes.RemoveAt(indexNote);

            _notes.Insert(indexNote, note);
        }

        /// <summary>
        /// Вывод записей на консоль
        /// </summary>
        public void PrintToConsole()
        {
            for (var i = 0; i < _index; i++)
            {
                Console.WriteLine($"Номер записи: {i} \n" +
                                  $"{_notes[i].Print()}");
            }
        }

        #endregion Methods
    }
}

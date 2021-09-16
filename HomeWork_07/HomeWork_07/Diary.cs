using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.String;

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
        /// Коллекция хранящий даты
        /// </summary>
        private List<DateTime> _dates;

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
            _dates = new List<DateTime>();
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
                var date = Convert.ToDateTime(data[2]);

                if (!_dates.Contains(date))
                {
                    _dates.Add(date);
                }

                AddNote(new Note(
                    data[0],
                    data[1],
                    Convert.ToDateTime(data[2]),
                    data[3],
                    data[4]));
            }
        }

        /// <summary>
        /// Сохранение записи
        /// </summary>
        /// <param name="path">Путь</param>
        public void Save(string path)
        {
            File.Delete(path);
            _dates.Clear();

            var temp = $"{_titles[0]},{_titles[1]},{_titles[2]},{_titles[3]},{_titles[4]}";

            File.AppendAllText(path, $"{temp}\n");

            for (var i = 0; i < _index; i++)
            {
                var date = _notes[i].DateCreate;

                if (!_dates.Contains(date))
                {
                    _dates.Add(date);
                }

                temp =
                    $"{_notes[i].Title}," +
                    $"{_notes[i].Author}," +
                    $"{_notes[i].DateCreate.ToShortDateString()}," +
                    $"{_notes[i].Content}," +
                    $"{_notes[i].Importance}";

                File.AppendAllText(path, $"{temp}\n");
            }
        }

        /// <summary>
        /// Добавление записи в коллекцию при выгрузки из файла
        /// </summary>
        /// <param name="note">Запись</param>
        public void AddNote(Note note)
        {
            _notes.Add(note);
            _index++;
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="number">Выбранный пункт</param>
        /// <param name="index">Индекс записи</param>
        /// <param name="text">Текст по которому нужно удалить</param>
        public void DeleteNote(int number, int index = default, string text = default)
        {
            switch (number)
            {
                case 1: // По номеру записи
                    _notes.RemoveAt(index);
                    break;
                case 2: // Title
                    foreach (var note in _notes.Where(note => note.Title == text))
                    {
                        _notes.Remove(note);
                    }
                    break;
                case 3: // Author
                    foreach (var note in _notes.Where(note => note.Author == text))
                    {
                        _notes.Remove(note);
                    }
                    break;
                case 4: // DateCreate
                    var date = _dates[index - 1];

                    foreach (var note in _notes.Where(note => note.DateCreate == date))
                    {
                        _notes.Remove(note);
                    }
                    break;
                case 5: // Content
                    foreach (var note in _notes.Where(note => note.Content == text))
                    {
                        _notes.Remove(note);
                    }
                    break;
                case 6: // Importance
                    foreach (var note in _notes.Where(note => note.Importance == text))
                    {
                        _notes.Remove(note);
                    }
                    break;
            }

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
        /// Сортировка записей
        /// </summary>
        public void SortNotes(int number)
        {
            switch (number)
            {
                case 1:
                    _notes.Sort((a, b) => string.Compare(a.Title, b.Title, StringComparison.Ordinal));
                    break;
                case 2:
                    _notes.Sort((a, b) => Compare(a.Author, b.Author, StringComparison.Ordinal));
                    break;
                case 3:
                    _notes.Sort((a, b) => a.DateCreate.CompareTo(b.DateCreate));
                    break;
                case 4:
                    _notes.Sort((a, b) => string.Compare(a.Content, b.Content, StringComparison.Ordinal));
                    break;
                case 5:
                    _notes.Sort((a, b) => Compare(a.Importance, b.Importance, StringComparison.Ordinal));
                    break;
            }
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

        /// <summary>
        /// Вывод дат на консоль
        /// </summary>
        public void PrintDatesToConsole()
        {
            for (var i = 0; i < _dates.Count; i++)
            {
                Console.WriteLine($" {i + 1}: {_dates[i].ToShortDateString()}");
            }
        }

        /// <summary>
        /// Нахождение даты записи и вывод
        /// </summary>
        /// <param name="index">Индекс записи</param>
        public void FindDate(int index)
        {
            var date = _dates[index - 1];

            foreach (var note in _notes.Where(note => date == note.DateCreate))
            {
                Console.WriteLine($"{note.Print()}");
            }
        }

        #endregion Methods
    }
}

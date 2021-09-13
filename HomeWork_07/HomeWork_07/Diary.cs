using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork_07
{
    struct Diary
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

        public Diary(string Path)
        {
            _path = Path;
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
            Print.Text($"Файла {_path} не существует. Создание файла.", ConsoleColor.DarkRed);

            using StreamWriter sWriter = new(new FileStream(_path, FileMode.Create, FileAccess.Write));
            const string temp = "GUID,Title,Author,DateCreate,Content,Importance";

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

                AddNote(new Note(data[1], data[2], Convert.ToDateTime(data[3]), data[4], data[5]));
            }
        }

        /// <summary>
        /// Сохранение данных в файл
        /// </summary>
        public void Save(string path)
        {
            var temp = $"{_titles[0]},{_titles[1]},{_titles[2]},{_titles[3]},{_titles[4]},{_titles[5]}";

            File.AppendAllText(path, $"{temp}\n");

            for (int i = 0; i < _index; i++)
            {
                temp =
                    $"{_notes[i].GUID}," +
                    $"{_notes[i].Title}," +
                    $"{_notes[i].Author}," +
                    $"{_notes[i].DateCreate}," +
                    $"{_notes[i].Content}," +
                    $"{_notes[i].Importance}";

                File.AppendAllText(path, $"{temp}\n");
            }
        }

        /// <summary>
        /// Добавление записи в массив
        /// </summary>
        /// <param name="note">Запись</param>
        public void AddNote(Note note)
        {
            _notes.Add(note);
            _index++;
        }

        public void PrintToConsole()
        {
            for (var i = 0; i < _index; i++)
            {
                Print.Text(_notes[i].Print());
            }
        }

        #endregion Methods
    }
}

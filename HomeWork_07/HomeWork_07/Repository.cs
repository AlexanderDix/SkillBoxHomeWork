using System;
using System.IO;

namespace HomeWork_07
{
    struct Repository
    {
        #region Fields

        /// <summary>
        /// Массив хранящий записи
        /// </summary>
        private Note[] _notes;

        /// <summary>
        /// Массив хранящий заголовки
        /// </summary>
        private string[] _titles;

        /// <summary>
        /// Название файла из которого берутся данные
        /// </summary>
        private string _path;

        /// <summary>
        /// Номер элемента в массиве notes
        /// </summary>
        private int _index;

        #endregion Fields

        #region Constructors

        public Repository(string Path)
        {
            _path = Path;
            _index = 0;
            _titles = Array.Empty<string>();
            _notes = new Note[1];

            Load();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Проверка существования файла
        /// </summary>
        private void FileExists()
        {
            if (!File.Exists(_path))
            {
                Print.Text($"Файла {_path} не существует. Создание файла.", ConsoleColor.DarkRed);

                using StreamWriter sWriter = new(new FileStream(_path, FileMode.Create, FileAccess.Write));
                string temp = string.Format("{0},{1},{2},{3},{4},{5}",
                                                "GUID",
                                                "Title",
                                                "Author",
                                                "DateCreate",
                                                "Content",
                                                "Importance");

                sWriter.WriteLine(temp);
            }
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
                string[] data = sReader.ReadLine().Split(',');

                AddNote(new Note(data[1], data[2], Convert.ToDateTime(data[3]), data[4], data[5]));
            }
        }

        /// <summary>
        /// Сохранение данных в файл
        /// </summary>
        public void Save(string path)
        {
            string temp = string.Format("{0},{1},{2},{3},{4},{5}",
                                            _titles[0],
                                            _titles[1],
                                            _titles[2],
                                            _titles[3],
                                            _titles[4],
                                            _titles[5]);

            File.AppendAllText(path, $"{temp}\n");

            for (int i = 0; i < _index; i++)
            {
                temp = string.Format("{0},{1},{2},{3},{4},{5}",
                                        _notes[i].GUID,
                                        _notes[i].Title,
                                        _notes[i].Author,
                                        _notes[i].DateCreate,
                                        _notes[i].Content,
                                        _notes[i].Importance);

                File.AppendAllText(path, $"{temp}\n");
            }
        }

        /// <summary>
        /// Изменяем размер массива notes
        /// </summary>
        /// <param name="check">Условие изменения размера</param>
        private void Resize(bool check)
        {
            if (check)
            {
                Array.Resize(ref _notes, _notes.Length * 2);
            }
        }

        /// <summary>
        /// Добавление записи в массив
        /// </summary>
        /// <param name="note">Запись</param>
        public void AddNote(Note note)
        {
            Resize(_index >= _notes.Length);
            _notes[_index] = note;
            _index++;
        }

        public void PrintToConsole()
        {
            for (int i = 0; i < _index; i++)
            {
                Print.Text(_notes[i].Print());
            }
        }

        #endregion Methods
    }
}

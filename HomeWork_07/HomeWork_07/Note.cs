using System;

namespace HomeWork_07
{
    /// <summary>
    /// Структура описывающая запись
    /// </summary>
    struct Note
    {
        #region Constructor

        /// <summary>
        /// Конструктор записи
        /// </summary>
        /// <param name="ID">Идентификатор</param>
        /// <param name="Title">Заголовок</param>
        /// <param name="Author">Автор</param>
        /// <param name="DateCreate">Дата создания</param>
        /// <param name="Content">Контент</param>
        /// <param name="Importance">Важность</param>
        public Note(string Title, string Author, DateTime DateCreate, string Content, string Importance)
        {
            _title = Title;
            _author = Author;
            _dateCreate = DateCreate;
            _content = Content;
            _importance = Importance;
            _guid = Guid.NewGuid().ToString();
        }

        #endregion Constructor

        #region Methods

        public string Print()
        {
            //return $"{_title,15} {_author,15} {_dateCreate,15} {_content,15} {_importance,15}";
            return $" Title:           {_title}\n" + 
                   $" Author:          {_author}\n" +
                   $" DateCreate:      {_dateCreate.ToShortDateString()}\n" +
                   $" Content:         {_content}\n" +
                   $" Importance:      {_importance}\n";
        }

        #endregion

        #region Fields

        /// <summary>
        /// Идентификатор записи
        /// </summary>
        private string _guid;

        /// <summary>
        /// Заголовк записи
        /// </summary>
        private string _title;

        /// <summary>
        /// Автор записи
        /// </summary>
        private string _author;

        /// <summary>
        /// Дата создания записи
        /// </summary>
        private DateTime _dateCreate;

        /// <summary>
        /// Содержание записи
        /// </summary>
        private string _content;

        /// <summary>
        /// Важность записи
        /// </summary>
        private string _importance;

        #endregion Fields

        #region Properties

        public string GUID { get { return _guid; } set { _guid = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Author { get { return _author; } set { _author = value; } }
        public DateTime DateCreate { get { return _dateCreate; } set { _dateCreate = value; } }
        public string Content { get { return _content; } set { _content = value; } }
        public string Importance { get { return _importance; } set { _importance = value; } }

        #endregion Properties
    }
}

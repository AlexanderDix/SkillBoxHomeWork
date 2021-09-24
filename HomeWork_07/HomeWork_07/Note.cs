using System;

namespace HomeWork_07
{
    /// <summary>
    /// Класс описывающий запись
    /// </summary>
    class Note
    {
        #region Constructor

        /// <summary>
        /// Конструктор записи
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="author">Автор</param>
        /// <param name="dateCreate">Дата создания</param>
        /// <param name="content">Контент</param>
        /// <param name="importance">Важность</param>
        public Note(string title, string author, DateTime dateCreate, string content, string importance)
        {
            Title = title;
            Author = author;
            _dateCreate = dateCreate;
            Content = content;
            Importance = importance;
        }

        #endregion Constructor

        #region Methods

        public string Print()
        {
            return $" Title:           {Title}\n" +
                   $" Author:          {Author}\n" +
                   $" DateCreate:      {_dateCreate.ToShortDateString()}\n" +
                   $" Content:         {Content}\n" +
                   $" Importance:      {Importance}\n";
        }

        #endregion

        #region Fields

        /// <summary>
        /// Дата создания записи
        /// </summary>
        private DateTime _dateCreate;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Заголовк записи
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Автор записи
        /// </summary>
        public string Author { get; set; }

        public DateTime DateCreate { get { return _dateCreate; } set { _dateCreate = value; } }

        /// <summary>
        /// Содержание записи
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Важность записи
        /// </summary>
        public string Importance { get; set; }

        #endregion Properties
    }
}

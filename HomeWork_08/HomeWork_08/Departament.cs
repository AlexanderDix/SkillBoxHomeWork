using System;
using System.Collections.Generic;

namespace HomeWork_08
{
    class Departament
    {
        #region Constructors

        public Departament(string name, DateTime dateCreate)
        {
            Name = name;
            DateCreate = dateCreate;
            Employees = new List<Employee>();
        }

        #endregion

        #region Properties

        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public List<Employee> Employees { get; set; }

        #endregion
    }
}
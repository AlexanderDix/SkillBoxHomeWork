using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_08
{
    class Company
    {
        #region Properties

        public string Name { get; set; }
        public List<Departament> Departaments { get; set; }

        #endregion

        #region Constructors

        public Company(string name)
        {
            Name = name;
            Departaments = new List<Departament>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Добавление департамента
        /// </summary>
        /// <param name="name">Название</param>
        public void AddDepartament(string name)
        {
            Departaments.Add(new Departament(name, DateTime.Now.ToShortDateString()));
        }

        /// <summary>
        /// Редактирование существующего департамента
        /// </summary>
        /// <param name="oldDepartament">Департамент который необходимо редактировать</param>
        /// <param name="name">Имя для нового департамента</param>
        public void EditDepartament(Departament oldDepartament, string name)
        {
            var index = Departaments.IndexOf(oldDepartament);
            var newDepartment = new Departament(name, DateTime.Now.ToShortDateString());

            foreach (var employee in oldDepartament.Employees)
            {
                newDepartment.Employees.Add(employee);
            }

            Departaments.RemoveAt(index);
            Departaments.Insert(index, newDepartment);
        }

        /// <summary>
        /// Удаление департамента
        /// </summary>
        /// <param name="departament">Департамент</param>
        public void DeleteDepartament(Departament departament)
        {
            Departaments.Remove(departament);
        }

        /// <summary>
        /// Сортировка департаментов
        /// </summary>
        public void SortDepartament()
        {
            var departaments = Departaments.OrderBy(dep => dep.Name).ToList();

            foreach (var departament in departaments)
            {
                InOut.Print($"{departament.Print(" ")}\n", ConsoleColor.DarkYellow);
            }
        }

        /// <summary>
        /// Поиск департамента по названию, введеному пользователем
        /// </summary>
        /// <param name="name">Название департамента</param>
        /// <returns>Возвращаем найденный департамент</returns>
        public Departament CurrentDepartament(string name)
        {
            return Departaments.Find(dep => dep.Name.Equals(name));
        }

        /// <summary>
        /// Вывод на консоль департаментов
        /// </summary>
        public void PrintDepartaments()
        {
            foreach (var departament in Departaments)
            {
                Console.WriteLine();
                InOut.Print($"{departament.Print()}\n", ConsoleColor.DarkYellow);
            }
        }

        /// <summary>
        /// Вывод на консоль работников
        /// </summary>
        public void PrintEmployees()
        {
            foreach (var employee in Departaments.SelectMany(dep => dep.Employees))
            {
                InOut.Print($"{employee.Print(" ")}\n", ConsoleColor.DarkGray);
            }
        }

        /// <summary>
        /// Вывод компании на консоль (департаменты + работники в них)
        /// </summary>
        public void PrintDepAndEmp()
        {
            foreach (var departament in Departaments)
            {
                InOut.Print($"{departament.Print(" ")}\n", ConsoleColor.DarkYellow);

                foreach (var employee in departament.Employees)
                {
                    InOut.Print($"{employee.Print("   ")}\n", ConsoleColor.DarkGray);
                }
            }
        }

        public void GenerateDepartament()
        {
            for (var i = 0; i < 2; i++)
            {
                var departament = new Departament($"IT {i}", DateTime.Now.AddDays(i).ToShortDateString());

                Departaments.Add(departament);

                departament.GenerateEmployee();
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_08
{
    class Departament
    {
        #region Fields

        #endregion

        #region Constructors

        public Departament(string name, string dateCreate)
        {
            Name = name;
            DateCreate = dateCreate;
            Employees = new List<Employee>();
        }

        #endregion

        #region Properties

        public string Name { get; set; }
        public string DateCreate { get; set; }
        public int CountEmployee => Employees.Count;
        public List<Employee> Employees { get; set; }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Добавление работника
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="salary">Зарплата</param>
        public void AddEmployee(string firstName, string lastName, int age, int salary)
        {
            Employees.Add(new Employee(firstName, lastName, age, salary, Name));
        }

        /// <summary>
        /// Редактирование работника
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="salary">Зарплата</param>
        public void EditEmployee(int index, string firstName, string lastName, int age, int salary)
        {
            Employees.RemoveAt(index);

            Employees.Insert(index, new Employee(firstName, lastName, age, salary, Name));
        }

        /// <summary>
        /// Удаление работника по имени или фамилии
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        public void DeleteEmployee(string firstName = default, string lastName = default)
        {
            Employee employee = null;

            if (firstName != default)
            {
                employee = Employees.FirstOrDefault(emp => emp.FirstName == firstName);
            }

            if (lastName != default)
            {
                employee = Employees.FirstOrDefault(emp => emp.LastName == lastName);
            }

            DeleteEmployee(employee);
        }

        /// <summary>
        /// Удаление работника по возрасту или зарплате
        /// </summary>
        /// <param name="age">Возраст</param>
        /// <param name="salary">Зарплата</param>
        public void DeleteEmployee(int age = default, int salary = default)
        {
            Employee employee = null;

            if (age != default)
            {
                employee = Employees.FirstOrDefault(emp => emp.Age == age);
            }

            if (salary != default)
            {
                employee = Employees.FirstOrDefault(emp => emp.Salary == salary);
            }

            DeleteEmployee(employee);
        }

        /// <summary>
        /// Вывод работников на консоль
        /// </summary>
        public void PrintEmployee()
        {
            for (var i = 0; i < Employees.Count; i++)
            {
                InOut.Print($" Номер записи: {i}\n" +
                            $"{Employees[i].Print("  ")}\n");
            }
        }

        /// <summary>
        /// Вывод работников после сортировки
        /// </summary>
        /// <param name="number"></param>
        public void PrintEmployeeAfterSort(int number)
        {
            var employees = SortEmployee(number);

            foreach (var employee in employees)
            {
                InOut.Print($"{employee.Print(" ")}\n", ConsoleColor.DarkGray);
            }
        }

        /// <summary>
        /// Вывод департаментов на консоль
        /// </summary>
        /// <param name="trim">Пробелы</param>
        /// <returns>Возвращаем строку</returns>
        public string Print(string trim = default)
        {
            return $"{trim}Name:          {Name}\n" +
                   $"{trim}DateCreate:    {DateCreate}\n" +
                   $"{trim}CountEmployee: {CountEmployee}";
        }

        /// <summary>
        /// Генерация работников
        /// </summary>
        public void GenerateEmployee()
        {
            for (var i = 0; i < 2; i++)
            {
                var employee = new Employee($"Employee {i}",
                    $"Smith",
                    i + 20,
                    i * 20000,
                    Name);

                Employees.Add(employee);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Удаление работника
        /// </summary>
        /// <param name="employee">Работник</param>
        private void DeleteEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        /// <summary>
        /// Сортировка работников по полю
        /// </summary>
        /// <param name="number">Номер поля</param>
        /// <returns>Возвращаем сортированный список</returns>
        private List<Employee> SortEmployee(int number)
        {
            var employees = number switch
            {
                1 => Employees.OrderBy(emp => emp.FirstName).ToList(),
                2 => Employees.OrderBy(emp => emp.LastName).ToList(),
                3 => Employees.OrderBy(emp => emp.Age).ToList(),
                4 => Employees.OrderBy(emp => emp.Salary).ToList(),
                _ => null
            };

            return employees;
        }

        #endregion

        #endregion
    }
}
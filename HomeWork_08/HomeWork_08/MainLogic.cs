using Newtonsoft.Json;
using System;
using System.IO;

namespace HomeWork_08
{
    class MainLogic
    {
        private static Company _company = new("Company");
        private const string Path = "company.json";

        #region Methods

        /// <summary>
        /// Добавление департамента
        /// </summary>
        public static void AddDepartament()
        {
            DeserializeCompany();
            InOut.Print("Введите название департамента:", ConsoleColor.DarkCyan);

            var input = Console.ReadLine();

            _company.AddDepartament(input);

            SerializeCompany();
        }

        /// <summary>
        /// Редактирование департамента
        /// </summary>
        public static void EditDepartament()
        {
            DeserializeCompany();

            InOut.Print("Выберите департамент для редактирования, введя название", ConsoleColor.DarkCyan);
            _company.PrintDepartaments();

            var departament = InputDepartament();

            var input = InOut.InputStr("Введите новое название департамента");

            _company.EditDepartament(departament, input);

            SerializeCompany();
        }

        /// <summary>
        /// Добавление работника
        /// </summary>
        public static void AddEmployee()
        {
            DeserializeCompany();

            InOut.Print("Выберите департамент, введя название:", ConsoleColor.DarkCyan);
            _company.PrintDepartaments();

            var departament = InputDepartament();

            InOut.Print("Введите данные работника", ConsoleColor.DarkCyan);

            InputEmployee(departament);

            SerializeCompany();
        }

        /// <summary>
        /// Редактирование работника
        /// </summary>
        public static void EditEmployee()
        {
            DeserializeCompany();

            InOut.Print("Выберите департамент, введя название", ConsoleColor.DarkCyan);
            _company.PrintDepartaments();

            var departament = InputDepartament();

            departament.PrintEmployee();

            var indexEmployee = InOut.InputInt("Введите номер записи которую хотите редактировать");

            InputEmployee(departament, indexEmployee + 1);

            SerializeCompany();
        }

        /// <summary>
        /// Сортировка департаментов
        /// </summary>
        public static void SortDepartament()
        {
            DeserializeCompany();

            _company.SortDepartament();

            SerializeCompany();

            OutputStub();
        }

        /// <summary>
        /// Удаление департамента
        /// </summary>
        public static void DeleteDepartament()
        {
            DeserializeCompany();

            InOut.Print("Выберите департамент для удаления, введя название:", ConsoleColor.DarkCyan);
            _company.PrintDepartaments();

            var departament = InputDepartament();

            _company.DeleteDepartament(departament);

            SerializeCompany();
        }

        /// <summary>
        /// Удаление сотрудника по выбраному полю
        /// </summary>
        public static void DeleteEmployee()
        {
            DeserializeCompany();

            InOut.Print("Выберите департамент для удаления в нем сотрудников, введя название:",
                ConsoleColor.DarkCyan);
            _company.PrintDepartaments();
            var departament = InputDepartament();

            InOut.Print("Список работников", ConsoleColor.DarkCyan);
            departament.PrintEmployee();

            var number = ChoiceFields();

            switch (number)
            {
                case 1:
                    departament.DeleteEmployee(InOut.InputStr("Введите данные для удаления по имени"));
                    break;
                case 2:
                    departament.DeleteEmployee(lastName: InOut.InputStr("Введите данные для удаления по фамилии"));
                    break;
                case 3:
                    departament.DeleteEmployee(InOut.InputInt("Введите данные для удаления по возрасту"));
                    break;
                case 4:
                    departament.DeleteEmployee(salary: InOut.InputInt("Введите данные для удаления по зарплате"));
                    break;
            }

            SerializeCompany();
        }

        /// <summary>
        /// Сортировка работника по полю
        /// </summary>
        public static void SortEmployee()
        {
            DeserializeCompany();

            InOut.Print("Выберите департамент, введя название:", ConsoleColor.DarkCyan);
            _company.PrintDepartaments();

            var departament = InputDepartament();

            departament.PrintEmployeeAfterSort(ChoiceFields());

            SerializeCompany();

            OutputStub();
        }

        /// <summary>
        /// Вывод на консоль работников
        /// </summary>
        public static void PrintEmployee()
        {
            DeserializeCompany();

            _company.PrintEmployees();

            OutputStub();
        }

        /// <summary>
        /// Вывод на консоль департаментов
        /// </summary>
        public static void PrintDepartament()
        {
            DeserializeCompany();

            _company.PrintDepartaments();

            OutputStub();
        }

        /// <summary>
        /// Вывод на консоль компании (департаменты + работники в них)
        /// </summary>
        public static void PrintCompany()
        {
            DeserializeCompany();

            _company.PrintDepAndEmp();

            OutputStub();
        }

        #region Private methods

        /// <summary>
        /// Сериализация компании
        /// </summary>
        private static void SerializeCompany()
        {
            var json = JsonConvert.SerializeObject(_company);

            File.WriteAllText(Path, json);
        }

        /// <summary>
        /// Десериализация компании
        /// </summary>
        private static void DeserializeCompany()
        {
            string json;
            if (File.Exists(Path))
            {
                json = File.ReadAllText(Path);
            }
            else
            {
                GenerateFiles();
                json = File.ReadAllText(Path);
            }
            _company = JsonConvert.DeserializeObject<Company>(json);
        }

        /// <summary>
        /// Ввод данных работника
        /// </summary>
        /// <param name="departament">Департамент</param>
        /// <param name="indexEmployee">Индекс работника</param>
        private static void InputEmployee(Departament departament, int indexEmployee = default)
        {
            var firstName = InOut.InputStr("Имя");
            var lastName = InOut.InputStr("Фамилия");
            var age = InOut.InputInt("Возраст");
            var salary = InOut.InputInt("Зарплата");

            if (indexEmployee != default)
            {
                departament.EditEmployee(indexEmployee - 1, firstName, lastName, age, salary);
            }
            else
            {
                departament.AddEmployee(firstName, lastName, age, salary);
            }
        }

        /// <summary>
        /// Ввод названия департамента (??)
        /// </summary>
        /// <returns>Возврат найденного департамента</returns>
        private static Departament InputDepartament()
        {
            while (true)
            {
                var input = Console.ReadLine();
                var departament = _company.CurrentDepartament(input);

                if (departament != null) return departament;

                InOut.Print("Такого департамента нет", ConsoleColor.DarkRed);
            }
        }

        /// <summary>
        /// Просим пользователя выбрать поле
        /// </summary>
        /// <returns></returns>
        private static int ChoiceFields()
        {
            InOut.Print("Выберите поле", ConsoleColor.DarkCyan);
            const string fields = " 1 - Имя\n" +
                                  " 2 - Фамилия\n" +
                                  " 3 - Возраст\n" +
                                  " 4 - Зарплата\n";
            InOut.Print(fields);

            while (true)
            {
                var number = InOut.InputInt();

                switch (number)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        return number;
                    default:
                        InOut.Print("Такого поля нет", ConsoleColor.DarkRed);
                        continue;
                }
            }
        }

        /// <summary>
        /// Генерация файла при отсутствии
        /// </summary>
        private static void GenerateFiles()
        {
            _company.GenerateDepartament();

            SerializeCompany();
        }

        /// <summary>
        /// Залушка после вывода данных
        /// </summary>
        private static void OutputStub()
        {
            InOut.Print("Для продолжения работы нажмите любую кнопку...", ConsoleColor.DarkCyan);

            Console.ReadKey();
        }

        #endregion Private methods

        #endregion Methods
    }
}

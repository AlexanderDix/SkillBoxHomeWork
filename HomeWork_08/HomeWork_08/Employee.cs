namespace HomeWork_08
{
    class Employee
    {
        #region Properties

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string Departament { get; set; }

        #endregion

        #region Constructors

        public Employee(int id, string firstName, string lastName, int age, int salary, string departament)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
            Departament = departament;
        }

        #endregion
    }
}
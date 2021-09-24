using System;

namespace HomeWork_08
{
    class Employee
    {
        #region Properties

        public string GuId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string Departament { get; set; }

        #endregion

        #region Constructors

        public Employee(string firstName, string lastName, int age, int salary, string departament)
        {
            GuId = GetGuid();
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
            Departament = departament;
        }

        #endregion

        #region Methods

        private string GetGuid()
        {
            return Guid.NewGuid()
                .ToString()
                .Substring(0, 6);
        }

        public string Print(string trim = default)
        {
            return $"{trim}GuID:          {GuId} \n" +
                   $"{trim}FirstName:     {FirstName} \n" +
                   $"{trim}LastName:      {LastName} \n" +
                   $"{trim}Age:           {Age} \n" +
                   $"{trim}Salary:        {Salary} \n" +
                   $"{trim}Department:    {Departament}";
        }

        #endregion
    }
}
using System;

namespace LINQ.Homework
{
    public class Employee {
        public Employee(int id, string name, int salary)
        {
            ID = id;
            Name = name;
            Salary = salary;
        }

        public Employee()
        {
        }

        public int ID { get; set; }
            public string Name { get; set; }
            public int Salary { get; set; }
        }
}
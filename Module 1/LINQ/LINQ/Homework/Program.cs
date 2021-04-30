using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.Homework
{
    class Program
    {
        public static void Main()
        {
            Employee employee1 = new Employee()
            {
                ID = 101,
                Name = "Mark",
                Salary = 4000
            };
            Employee employee2 = new Employee()
            {
                ID = 103,
                Name = "John",
                Salary = 7000
            };
            Employee employee3 = new Employee()
            {
                ID = 102,
                Name = "Ken",
                Salary = 5500
            };
            List<Employee> listEmployees = new List<Employee>();
            listEmployees.Add(employee1);
            listEmployees.Add(employee2);
            listEmployees.Add(employee3);
            Console.WriteLine("Employees before sorting");
            foreach (Employee Employee in listEmployees)
            {
                Console.WriteLine(Employee.ID);
            }

            //simple way
            listEmployees.Sort(CompareEmployees);

            //anonymous method
            listEmployees.Sort(delegate(Employee emp1, Employee emp2)
            {
                return emp1.ID.CompareTo(emp2.ID);
            });
            
            //lambda expression
            listEmployees.Sort(((emp1, emp2) => emp1.ID.CompareTo(emp2.ID)));
            Console.WriteLine("Employees after sorting by ID");
            foreach (Employee Employee in listEmployees)
            {
                Console.WriteLine(Employee.ID);
            }

            //extension methods
            Console.WriteLine(listEmployees.GetFirstElement());
            ListExtensions.GetFirstElement(listEmployees); //extension method will be called during 

            var orderedListOfHighSalaryEmployees = listEmployees
                .Where(employee => employee.Salary > 5000)
                .OrderBy(employee => employee.Name)
                .ToList();
            //listEmployees.Add(new Employee(104, "Any", 9000)); //will not be added to the query
            foreach (Employee Employee in orderedListOfHighSalaryEmployees)
            {
                Console.WriteLine(Employee.ID);
            }
            
            var highSalaryEmployees = listEmployees
                .Where(employee => employee.Salary > 5000)
                .Select(employee => new {employee.ID, employee.Name}); //anonymous types

            var firstEmployee = highSalaryEmployees.First();

            listEmployees.Add(new Employee(104, "Any", 9000)); //will be added
            foreach (var employee in highSalaryEmployees.ToList())
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine($"First employee in the high salary list: {firstEmployee}"); //102
        }
        public static int CompareEmployees(Employee c1, Employee c2)
        {
            return c1.ID.CompareTo(c2.ID);
        }
    }
}
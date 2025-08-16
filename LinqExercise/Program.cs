using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            // Print the Sum of numbers
            var sum = (from n in numbers select n).Sum();
            Console.WriteLine($"Sum: {sum}");

            // Print the Average of numbers
            var avg = (from n in numbers select n).Average();
            Console.WriteLine($"Average: {avg}");

            // Order numbers in ascending order and print to the console
            var asc = from n in numbers
                      orderby n ascending
                      select n;
            Console.WriteLine("Ascending:");
            foreach (var n in asc) Console.WriteLine(n);

            // Order numbers in descending order and print to the console
            var desc = from n in numbers
                       orderby n descending
                       select n;
            Console.WriteLine("Descending:");
            foreach (var n in desc) Console.WriteLine(n);

            // Print to the console only the numbers greater than 6
            var greaterThanSix = from n in numbers
                                 where n > 6
                                 select n;
            Console.WriteLine("Greater than 6:");
            foreach (var n in greaterThanSix) Console.WriteLine(n);

            // Order numbers in any order but only print 4 of them
            var firstFour = (from n in numbers
                             orderby n ascending
                             select n).Take(4);
            Console.WriteLine("First 4 numbers:");
            foreach (var n in firstFour) Console.WriteLine(n);

            // Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 30; // replace 30 with your age
            var ageReplaced = from n in numbers
                              orderby n descending
                              select n;
            Console.WriteLine("After replacing index 4 with age:");
            foreach (var n in ageReplaced) Console.WriteLine(n);

            // List of employees
            var employees = CreateEmployees();

            // Print FullName if FirstName starts with C or S, order by FirstName ascending
            var csEmployees = from e in employees
                              where e.FirstName.StartsWith("C") || e.FirstName.StartsWith("S")
                              orderby e.FirstName ascending
                              select e.FullName;
            Console.WriteLine("Employees with C or S:");
            foreach (var name in csEmployees) Console.WriteLine(name);

            // Print FullName and Age of employees > 26, ordered by Age then FirstName
            var over26 = from e in employees
                         where e.Age > 26
                         orderby e.Age, e.FirstName
                         select new { e.FullName, e.Age };
            Console.WriteLine("Employees over 26:");
            foreach (var e in over26) Console.WriteLine($"{e.FullName}, Age: {e.Age}");

            // Sum of YOE if YOE <= 10 AND Age > 35
            var yoeSum = (from e in employees
                          where e.YearsOfExperience <= 10 && e.Age > 35
                          select e.YearsOfExperience).Sum();
            Console.WriteLine($"YOE Sum: {yoeSum}");

            // Average of YOE if YOE <= 10 AND Age > 35
            var yoeAvg = (from e in employees
                          where e.YearsOfExperience <= 10 && e.Age > 35
                          select e.YearsOfExperience).Average();
            Console.WriteLine($"YOE Average: {yoeAvg}");

            // Add an employee to the end of the list without using employees.Add()
            employees = employees.Concat(new List<Employee>
            {
                new Employee("New", "Hire", 28, 2)
            }).ToList();

            Console.WriteLine("Employees after adding new hire:");
            foreach (var e in employees) Console.WriteLine(e.FullName);

            Console.ReadLine();
        }

        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
    }
}

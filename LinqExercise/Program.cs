using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            Console.WriteLine($"Sum is = {numbers.Sum()}");
            Console.WriteLine($"Average is = {numbers.Average()}");
            var numbersOrder = numbers.OrderBy(num => num);
            foreach (var numb in numbersOrder) 
            {
                Console.WriteLine(numb);
            }
           var numbersOrderDes = numbers.OrderByDescending(num => num);
            foreach (var numb in numbersOrderDes)
            {
                Console.WriteLine(numb); 
            }
           var numbersOverSix = numbers.Where(num => num > 6);
            foreach (var numb in numbersOverSix)
            {
                Console.WriteLine(numb);
            }
            var onlyFour = numbers.Take(4);
            foreach (var numb in onlyFour)
            {
                Console.WriteLine(numb);
            }
            numbers[4] = 27;
            foreach (var numb in numbersOrderDes)
            {
                Console.WriteLine(numb);
            }                       

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            var nameStartCOrS = employees.Where(name => name.FirstName.ToUpper().StartsWith("C") || name.FirstName.ToUpper().StartsWith("S"));
            
                //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            //TODO: Add an employee to the end of the list without using employees.Add()
            foreach(var name in nameStartCOrS.OrderBy(name => name.FirstName))
            {
                Console.WriteLine(name.FullName);
            }
            var ageOver26 = employees.Where(employeeAge => employeeAge.Age > 26);
            foreach (var age in ageOver26.OrderBy(employeeAge => employeeAge.Age).ThenBy(employeeAge => employeeAge.FirstName))
            {
                Console.WriteLine(age.FullName);
                Console.WriteLine(age.Age);
            }
            var expOver10AgeOver35 = employees.Where(employeeYOE => employeeYOE.YearsOfExperience <= 10 && employeeYOE.Age > 35);
            Console.WriteLine($"Sum of employees experience with at most 10 years exp who are over age 35 = {expOver10AgeOver35.Sum(sum => sum.YearsOfExperience)}");
            Console.WriteLine($"Average of employees experience with at most 10 years exp who are over age 35 = {expOver10AgeOver35.Average(average => average.YearsOfExperience)}");

            employees = employees.Append(new Employee("Star", "Schweitzer", 25, 5)).ToList();


            foreach(var employee in employees)
            {
                Console.WriteLine(employee.FullName);
            }
        }

        #region CreateEmployeesMethod
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
        #endregion
    }
}

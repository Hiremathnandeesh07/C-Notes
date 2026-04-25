using EmploymentManagementSystemProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentManagementSystemProj.Services
{
    internal class EmployeeService 
    {


        protected List<Employee> employees = new List<Employee>();

        
        internal List<Employee> GetEmployeesInternal()
        {
            return employees;
        }






        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        // method for displaying employees with all its details
        public void ViewEmployees()
        {
            Console.WriteLine($"Company Name {Employee.CompanyName}");
            foreach (Employee emp in employees)
            {
                if (emp is PartTimeEmployee ptm)
                {
                    Console.WriteLine(
                        $"{ptm.empId,-10}{ptm.empName,-20}{ptm.empSalary,-15:F2}Part-Time \n"
                    );
                }
                if (emp is FullTimeEmployee ftm)
                {
                    Console.WriteLine(
                        $"{ftm.empId,-10}{ftm.empName,-20}{ftm.empSalary,-15:F2}Full-Time \n"
                    );
                }

            }
        }



        // Displaying with bonus calculated
        public void ViewEmployeesWithBonusCalculated()
        {
            Console.WriteLine($"Company Name :  {Employee.CompanyName}");
            foreach (Employee emp in employees)
            {
                double bonus = emp.CalculateBonus();
                if (emp is PartTimeEmployee ptm)
                {

                    Console.WriteLine(
                        $"{ptm.empId,-10}{ptm.empName,-20}{ptm.empSalary,-20} {bonus,-15:F2}Part-Time \n"
                    );
                }
                if (emp is FullTimeEmployee ftm)
                {
                    Console.WriteLine(
                        $"{ftm.empId,-10}{ftm.empName,-20}{ftm.empSalary,-20}{bonus,-15:F2}Full-Time \n"
                    );
                }

            }
        }
        

public static string ReverseWordOrder(string name)
        {

            string[] parts = name.Split(' ');

            Array.Reverse(parts);

            return string.Join(" ", parts);


            // ADVANCED METHOD
            //return string.Join(
            //    " ",
            //    name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //        .Reverse()
            //);
        }


        // Reversing the names of the Employee

        public void ViewEmployeesWithReveredEmployeeNames()
        {
            Console.WriteLine($"Company Name {Employee.CompanyName}");
            foreach (Employee emp in employees)
            {
                string newName = ReverseWordOrder(emp.empName);
    
                if (emp is PartTimeEmployee ptm)
                {
                    Console.WriteLine(
                        $"Original Name is : {emp.empName} and Reversed Name is : {newName}"
                    );
                }
                if (emp is FullTimeEmployee ftm)
                {
                    Console.WriteLine(
                        $"Original Name is : {emp.empName} and Reversed Name is : {newName}"
                    );
                }

            }
        }

        // finding the duplicate names
        public List<string> FindDuplicateNames()
        {
            Dictionary<string, int> namesMap = new Dictionary<string, int>();
            List<string> duplicateNames = new List<string>();

            //  Count occurrences of each name
            foreach (Employee emp in employees)
            {
                if (namesMap.ContainsKey(emp.empName))
                {
                    namesMap[emp.empName]++;
                }
                else
                {
                    namesMap[emp.empName] = 1;
                }
            }

            //  Collect names that appear more than once
            foreach (var item in namesMap)
            {
                if (item.Value > 1)
                {
                    duplicateNames.Add(item.Key);
                }
            }

            return duplicateNames;
        }




    }
}

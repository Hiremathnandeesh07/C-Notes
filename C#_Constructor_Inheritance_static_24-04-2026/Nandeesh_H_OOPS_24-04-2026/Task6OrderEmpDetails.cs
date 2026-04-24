using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nandeesh_H_OOPS_24_04_2026
{
    /*
    * create 2 methods to display employee detailes like id and name
    * user should be flexible to pass in order 
    */
    internal class Task6OrderEmpDetails
    {
        private int employeeId;
        private string name;
        private double salary;
        public static string companyName = "Acuvate";
        public void AcceptEmployeeDetails(int employeeId, string name, double salary)
        {
            this.employeeId = employeeId;
            this.name = name;
            this.salary = salary;
        }


        public void AcceptEmployeeDetails1(string name, int employeeId,double salary)
        {
            this.employeeId = employeeId;
            this.name = name;
            this.salary = salary;
        }
        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Employee Id :{employeeId}");
            Console.WriteLine($"Employee Name :{name}");
            Console.WriteLine($"Employee Salary :{salary}");
        }

    }
}

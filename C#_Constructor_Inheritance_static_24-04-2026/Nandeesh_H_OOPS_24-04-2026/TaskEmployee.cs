using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nandeesh_H_OOPS_24_04_2026
{
    /*
     * create emplyee class
     * empid,name,salary,company name
     * and create suitable types of variables (instance/static) for the above
     * 
     * create two methods for accepting and displaying empployee details
     * 
     * 
     * create another class for compnay which is used by all the employees
     * 
     * finally acess both the classes by creating three objects for emplyees
     * int main class
     */


    class Company
    {
        public static string CompanyName = "Acuvate Software";
    }

    internal class TaskEmployee
    {
        
            int empId;              // instance variable
            string name;            // instance variable
            double salary;          // instance variable

            // Method to accept employee details
            public void AcceptDetails()
            {
                Console.Write("Enter Employee ID: ");
                empId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Name: ");
                name = Console.ReadLine();

                Console.Write("Enter Salary: ");
                salary = Convert.ToDouble(Console.ReadLine());
            }

            // Method to display employee details
            public void DisplayDetails()
            {
                Console.WriteLine("\nEmployee ID : " + empId);
                Console.WriteLine("Name        : " + name);
                Console.WriteLine("Salary      : " + salary);
                Console.WriteLine("Company     : " + Company.CompanyName);
            }
        
    }
}

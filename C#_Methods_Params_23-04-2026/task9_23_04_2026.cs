using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{   
    /*
     * accept the employee name and branch of a company you should
     * display the name followed by branch but user can pass in any order
     * 
     * display like name is this and place is this
     */
    internal class task9_23_04_2026
    {
        static void DisplayEmployeeDetails(string empCompany, string empName)
        {
            Console.WriteLine($"employee name is {empName} and company is {empCompany}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter name of the employee : ");
            string name = Console.ReadLine();
            Console.WriteLine("enter branch of the company : ");
            string company = Console.ReadLine();
            DisplayEmployeeDetails(empName: name, empCompany: company);
            DisplayEmployeeDetails(empCompany: company, empName: name);

        }
    }
}

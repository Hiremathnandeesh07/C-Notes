using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{    
    /*
     * take employee name id and salary and try to reorder in method call but it should work correctly
     */
    internal class task8_23_04_2026
    {
        static void DisplayEmployeeDetails(string empid, string empName,int empSalary)
        {
            Console.WriteLine($"employee name is {empName} and id is {empid} and salary is {empSalary}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter name of the employee : ");
            string name = Console.ReadLine();
            Console.WriteLine("enter id  : ");
            string id = Console.ReadLine();
            Console.WriteLine("enter salary : ");
            int salary = Convert.ToInt32(Console.ReadLine());
            DisplayEmployeeDetails(empName: name, empid: id,empSalary:salary);
            DisplayEmployeeDetails(empid: id,empSalary:salary, empName: name);

        }
    }
}

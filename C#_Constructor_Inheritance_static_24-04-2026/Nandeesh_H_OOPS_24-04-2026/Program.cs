using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nandeesh_H_OOPS_24_04_2026
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //TASK_03_CODE
            Task3OverLoading t1 = new Task3OverLoading();
            Console.WriteLine(t1.Add(4, 5, 6));
            Console.WriteLine(t1.Add(234.2323, 342.23543, 3411.3453));


            //TASK_04_CODE

            Task4Manager m = new Task4Manager();

            m.Name = "Nandeesh";
            m.EmployeeId = 101;
            m.Department = "IT";

            m.DisplayName();         // from Person
            m.DisplayEmployeeId();   // from Employee
            m.DisplayDepartment();   // from Task4Manager

            //TASK_05_CODE
            Hostel h = new Hostel("nandeesh", 342, 2332);
            Console.WriteLine(h.name);
            Console.WriteLine(h.hostelId);
            Console.WriteLine(h.stdId);


            //TASK_06_CODE
            Task6OrderEmpDetails emp = new Task6OrderEmpDetails();
            emp.AcceptEmployeeDetails(2323, "nandeesh", 333333);
            emp.DisplayEmployeeDetails();
            emp.AcceptEmployeeDetails1("nandeesh", 33, 23442);
            emp.DisplayEmployeeDetails();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nandeesh_H_OOPS_24_04_2026
{
    /*
     * impliment multilevel inheritance
     */
    internal class Task4Person

    {


        public string Name;

        public void DisplayName()
        {
            Console.WriteLine("Name: " + Name);

        }
    }

    class Task4Employee : Task4Person
    {
        public int EmployeeId;

        public void DisplayEmployeeId()
        {
            Console.WriteLine("Employee ID: " + EmployeeId);
        }
    }

    class Task4Manager : Task4Employee
    {
        public string Department;

        public void DisplayDepartment()
        {
            Console.WriteLine("Department: " + Department);
        }
    }




}
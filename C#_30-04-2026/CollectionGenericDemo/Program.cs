using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionGenericDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employees> EmpList = new List<Employees>();


            //creating objects
            Employees e1 = new Employees();
            e1.Id = 34;
            e1.Name = "nandeesh";


            Employees e2 = new Employees();
            e2.Id = 56;
            e2.Name="anotherName";

            // adding objects in list
            EmpList.Add(e1);
            EmpList.Add(e2);


            // displaying the objects of employeess
            Console.WriteLine("------list of employees -------");

            
            foreach(var emp in EmpList)
            {
                Console.WriteLine($"{emp.Id}\t{emp.Name}");
            }
        }
    }
}

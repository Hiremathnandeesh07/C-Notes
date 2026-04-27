using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new FullTimeEmployee
            {
                name = "nandeesh",
                MonthlySalary=34000
            };

            Employee e2 = new PartTimeEmployee
            {
                name = "sam",
                ratePerHour = 20,
                totalWorkedHours = 23
            };

            Console.WriteLine(e1.CalcSalary());
            Console.WriteLine(e2.CalcSalary());

            

        }
    }
}

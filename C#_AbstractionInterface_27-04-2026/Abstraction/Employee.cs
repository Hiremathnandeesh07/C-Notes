using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    abstract class Employee
    {
        public string name { set; get; }

        public abstract double CalcSalary();


        public void DisplayName()
        {
            Console.WriteLine($"name is : {name}");
        }
    }

    class FullTimeEmployee : Employee
    {
        public  double MonthlySalary { set; get; }

        public override double CalcSalary()
        {
            return MonthlySalary;
        }
    }

    class PartTimeEmployee : Employee
    {
        public int totalWorkedHours { set; get; }
        public double ratePerHour { set; get; }

        public override double CalcSalary()
        {
            return totalWorkedHours * ratePerHour;
        }
    }
}

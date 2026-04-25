using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentManagementSystemProj.Models
{
    internal class PartTimeEmployee : Employee
    {

        //private int Bonus;


        public PartTimeEmployee(int empId, string empName, double empSalary) : base(empId,empName,empSalary)
        {
            //this.Bonus = 5;
        }

        public  override double CalculateBonus()
        {
            return empSalary*0.05;
        }

        
    }
}

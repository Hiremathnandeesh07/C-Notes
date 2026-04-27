using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentManagementSystemProj.Models
{
    internal class FullTimeEmployee : Employee
    {
        
        //private int Bonus;

        public FullTimeEmployee(int empId, string empName, double empSalary) : base(empId, empName, empSalary)
        {
            
        }

        public override double CalculateBonus()
        {
            return EmpSalary*0.2;
        }

    }
}

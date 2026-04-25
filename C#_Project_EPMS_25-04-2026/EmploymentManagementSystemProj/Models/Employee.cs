using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentManagementSystemProj.Models
{
    internal class Employee
    {
        public int empId;
        public string empName;
        public double empSalary;
        public static string CompanyName = "Acuvate Software Pvt Ltd";


        //base constructor
        public Employee(int empId,string empName,double empSalary)
        {
            this.empId = empId;
            this.empName = empName;
            this.empSalary = empSalary;
        }

        //Method to calculate bonus
        public virtual double CalculateBonus()
        {
            return 0;
        }

        //Method to DisplayDetails
        public void DisplayDetails()
        {

        }
    }
    
}

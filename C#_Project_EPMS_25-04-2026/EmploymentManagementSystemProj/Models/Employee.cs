using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentManagementSystemProj.Models
{
    internal class Employee
    {
        private int empId;
        private string empName;
        private double empSalary;
        public static string CompanyName = "Acuvate Software Pvt Ltd";


        // get set method tp access and set values
        public int EmpId
        {
            get
            {
                return empId;
            }
            set
            {
                empId = value;
            }
        }

        public string EmpName
        {
            get
            {
                return empName;
            }
            set
            {
                empName = value;
            }
        }

        public double EmpSalary
        {
            get
            {
                return empSalary;
            }
            set
            {
                empSalary = value;
            }
        }


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

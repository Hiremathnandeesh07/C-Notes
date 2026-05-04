using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__StudentCourseFeeManagementSystem_02_05_2026
{
    internal class Student
    {
        public Student(int studentId, string name, string courseName, decimal totalFee, decimal feePaid, DateTime admissionDate)
        {
            StudentId = studentId;
            Name = name;
            CourseName = courseName;
            TotalFee = totalFee;
            FeePaid = feePaid;
            AdmissionDate = admissionDate;
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public string CourseName { get; set; }
        public decimal TotalFee { get; set; }
        public decimal FeePaid { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}

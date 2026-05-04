using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__StudentCourseFeeManagementSystem_02_05_2026
{
    internal class Course
    {
        public Course(int courseId, string courseName, decimal fee)
        {
            CourseId = courseId;
            CourseName = courseName;
            Fee = fee;
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal Fee { get; set; }

    }
}

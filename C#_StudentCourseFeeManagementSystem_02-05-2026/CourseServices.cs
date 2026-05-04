using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__StudentCourseFeeManagementSystem_02_05_2026
{
    internal class CourseServices
    {
        public static List<Course> courses = new List<Course>();


        public static void AddCourse(int courseId, string courseName, decimal fee)
        {
            courses.Add(new Course(courseId, courseName, fee));
        }


        public static void DisplayCourses()
        {
            foreach (var c in courses)
            {
                Console.WriteLine($"{c.CourseId} - {c.CourseName} - Fee: {c.Fee}");
            }
        }


        public static void DeleteCourse()
        {
            Console.WriteLine("Enter the Course ID that you want to delete:");
            int id = Convert.ToInt32(Console.ReadLine());

            Course course = null;

            foreach (var c in courses)
            {
                if (c.CourseId == id)
                {
                    course = c;
                }
            }

            if (course == null)
            {
                Console.WriteLine("Invalid course ID");
                return;
            }

            foreach (var s in StudentServices.students)
            {
                if (course.CourseName == s.CourseName)
                {
                    Console.WriteLine("Course name can not be deleted because one students are already enrolled in this course.");
                    return;
                }
            }

            courses.Remove(course);
        }
    }
}

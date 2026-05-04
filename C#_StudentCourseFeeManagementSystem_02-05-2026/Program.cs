using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__StudentCourseFeeManagementSystem_02_05_2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Student Course and Fees Management System!");

            while (true)
            {
                Console.WriteLine("Choose any options below:");
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Display Courses");
                Console.WriteLine("4. Display Students");
                Console.WriteLine("5. Update Student");
                Console.WriteLine("6. Update Fee Paid");
                Console.WriteLine("7. Delete Student");
                Console.WriteLine("8. Delete Course");
                Console.WriteLine("9. Monthly revenue");
                Console.WriteLine("10. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Console.Write("Course Id: ");
                        int courseId = int.Parse(Console.ReadLine());

                        Console.Write("Course Name: ");
                        string courseName = Console.ReadLine();

                        Console.Write("Fee: ");
                        decimal fee = decimal.Parse(Console.ReadLine());

                        CourseServices.AddCourse(courseId, courseName, fee); break;

                    case 2:
                        Console.Write("Student Id: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Course Name: ");
                        string cName = Console.ReadLine();

                        Course course = null;

                        foreach (var c in CourseServices.courses)
                        {
                            if (c.CourseName == cName)
                            {
                                course = c;
                                break;
                            }

                        }

                        if (course == null)
                        {
                            Console.WriteLine("Course not found!");
                            break;
                        }

                        StudentServices.AddStudent(id, name, cName, course.Fee, 0, DateTime.Now);
                        break;


                    case 3:
                        CourseServices.DisplayCourses();
                        break;

                    case 4:
                        StudentServices.DisplayStudent();
                        break;

                    case 5:
                        StudentServices.UpdateStudent();
                        break;

                    case 6:
                        StudentServices.UpdateFee();
                        break;

                    case 7:
                        StudentServices.DeleteStudent(); break;

                    case 8:
                        CourseServices.DeleteCourse();
                        break;

                    case 9:
                        StudentServices.MonthlyRevenue();
                        break;

                    case 10: return;

                }
            }

        }
    }
}


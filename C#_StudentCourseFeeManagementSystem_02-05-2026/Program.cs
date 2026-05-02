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

            using System;

class Program
        {
            static void Main()
            {
                int choice;

                do
                {
                    Console.WriteLine("\n===== STUDENT MANAGEMENT MENU =====");
                    Console.WriteLine("1. Add Course");
                    Console.WriteLine("2. Add Student");
                    Console.WriteLine("3. View All Students");
                    Console.WriteLine("4. View All Courses");
                    Console.WriteLine("5. Update Student");
                    Console.WriteLine("6. Delete Student");
                    Console.WriteLine("7. Search Student by Name");
                    Console.WriteLine("8. Search by Course");
                    Console.WriteLine("9. Search Students with Fee Due");
                    Console.WriteLine("10. Search by Admission Month");
                    Console.WriteLine("11. Exit");
                    Console.Write("Enter your choice: ");

                    bool isValid = int.TryParse(Console.ReadLine(), out choice);

                    if (!isValid)
                    {
                        Console.WriteLine("Invalid input. Enter a number.");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            AddCourse();
                            break;
                        case 2:
                            AddStudent();
                            break;
                        case 3:
                            ViewAllStudents();
                            break;
                        case 4:
                            ViewAllCourses();
                            break;
                        case 5:
                            UpdateStudent();
                            break;
                        case 6:
                            DeleteStudent();
                            break;
                        case 7:
                            SearchStudentByName();
                            break;
                        case 8:
                            SearchByCourse();
                            break;
                        case 9:
                            SearchStudentsWithFeeDue();
                            break;
                        case 10:
                            SearchByAdmissionMonth();
                            break;
                        case 11:
                            Console.WriteLine("Exiting application...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }

                } while (choice != 11);
            }

            // ===== Method stubs =====

            static void AddCourse()
            {
                Console.WriteLine("Add Course logic here");
            }

            static void AddStudent()
            {
                Console.WriteLine("Add Student logic here");
            }

            static void ViewAllStudents()
            {
                Console.WriteLine("View All Students logic here");
            }

            static void ViewAllCourses()
            {
                Console.WriteLine("View All Courses logic here");
            }

            static void UpdateStudent()
            {
                Console.WriteLine("Update Student logic here");
            }

            static void DeleteStudent()
            {
                Console.WriteLine("Delete Student logic here");
            }

            static void SearchStudentByName()
            {
                Console.WriteLine("Search Student by Name logic here");
            }

            static void SearchByCourse()
            {
                Console.WriteLine("Search by Course logic here");
            }

            static void SearchStudentsWithFeeDue()
            {
                Console.WriteLine("Search Students with Fee Due logic here");
            }

            static void SearchByAdmissionMonth()
            {
                Console.WriteLine("Search by Admission Month logic here");
            }
        }






    }
    }
}

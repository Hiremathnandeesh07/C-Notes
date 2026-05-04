using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__StudentCourseFeeManagementSystem_02_05_2026
{
    
        internal class StudentServices
        {
            public static List<Student> students = new List<Student>();



// display student
        public static void DisplayStudent()
        {
            foreach(var item in students)
            {
                Console.WriteLine($"{item.StudentId} {item.Name} {item.CourseName} {item.TotalFee} {item.FeePaid} {item.AdmissionDate}");
            }
        }


            //Adding student

            public static void AddStudent(int studentId, string name, string courseName, decimal totalFee, decimal feePaid, DateTime admissionDate)
            {
                foreach (var s in students)
                {
                    if (s.StudentId == studentId)
                    {
                        Console.WriteLine("Student ID already exists! Cannot add duplicate.");
                        return;
                    }
                }

                if (feePaid > totalFee)
                {
                    Console.WriteLine("FeePaid cannot exceed TotalFee.");
                    return;
                }

                students.Add(new Student(studentId, name, courseName, totalFee, feePaid, admissionDate));

                Console.WriteLine("Student added successfully.");
            }


            //Updating student data
            public static void UpdateStudent()
            {
                Console.Write("Enter Student Id: ");
                int id = int.Parse(Console.ReadLine());

                var student = students.FirstOrDefault(s => s.StudentId == id);
                if (student == null)
                {
                    Console.WriteLine("Student not found!");
                    return;
                }

                while (true)
                {
                    Console.WriteLine("Enter what do you want to update of student with ID  + id");
                    Console.WriteLine("\n1. name");
                    Console.WriteLine("2. course name");
                    Console.WriteLine("3. admission date");
                    Console.WriteLine("4. Exit");


                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter New Name: ");
                            student.Name = Console.ReadLine();
                            break;

                        case 2:
                            Console.Write("Enter New Course Name: ");
                            student.CourseName = Console.ReadLine();
                            break;

                        case 3:
                            Console.Write("Enter New Name: ");
                            student.AdmissionDate = Convert.ToDateTime(Console.ReadLine());
                            break;

                        case 4:
                            return;

                    }
                }

            }



            //Updating Paid fees
            public static void UpdateFee()
            {
                //Console.Write("Enter Student Id: ");
                //int id = int.Parse(Console.ReadLine());

                //Student student = null;

                //foreach (var s in students)
                //{
                //    if (s.StudentId == id)
                //    {
                //        student = s;
                //        break;
                //    }
                //}

                //if (student == null)
                //{
                //    Console.WriteLine("Student not found!");
                //    return;
                //}

                //Console.Write("Enter amount to pay: ");
                //decimal amount = decimal.Parse(Console.ReadLine());

                //if(amount <= student.TotalFee)
                //{
                //    student.FeePaid += amount;
                //}
                //else
                //{
                //    Console.WriteLine("Invalid fees amount. Can not pay more than the total amount of fees!");
                //    return;
                //}
                try
                {
                    Console.Write("Enter Student Id: ");
                    int id = int.Parse(Console.ReadLine());

                    var student = students.FirstOrDefault(s => s.StudentId == id);
                    if (student == null)
                        throw new Exception("Student not found");

                    Console.Write("Enter amount to pay: ");
                    decimal amount = decimal.Parse(Console.ReadLine());

                    if (amount <= 0)
                        throw new Exception("Amount must be positive");

                    if (student.FeePaid + amount > student.TotalFee)
                        throw new Exception("FeePaid cannot exceed TotalFee");

                    student.FeePaid += amount;

                    Console.WriteLine("Payment successful");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }


            //Delete student data
            public static void DeleteStudent()
            {
                Console.Write("Enter Student Id: ");
                int id = int.Parse(Console.ReadLine());

                Student student = null;

                foreach (var s in students)
                {
                    if (s.StudentId == id)
                    {
                        student = s;
                        break;
                    }
                }

                if (student != null)
                {
                    students.Remove(student);
                }
            }


            public static void MonthlyRevenue()
            {
                Dictionary<string, decimal> revenueMap = new Dictionary<string, decimal>();

                foreach (var student in StudentServices.students)
                {
                    string key = student.AdmissionDate.Month + "/" + student.AdmissionDate.Year;

                    if (revenueMap.ContainsKey(key))
                    {
                        revenueMap[key] += student.FeePaid;
                    }
                    else
                    {
                        revenueMap[key] = student.FeePaid;
                    }
                }

                foreach (var item in revenueMap)
                {
                    Console.WriteLine($"{item.Key} : Revenue = {item.Value}");
                }
            }
        
    }
}

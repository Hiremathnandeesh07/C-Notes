using EmploymentManagementSystemProj.Models;
using EmploymentManagementSystemProj.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmploymentManagementSystemProj
{
    internal abstract class Program
        // the reason i made this class ABSTRACT is that i am not creating any EMPLOYEE object type as there is no meaning in doing it
        // because that particular employee cannot be considered as either FULL TIME or PART TIME
    {
        static void Main(string[] args)
        {
            AuthService AuthServiceObj = new AuthService();
            Console.WriteLine("Welcome To Employee Management System : ");
            Console.WriteLine("Please Enter the Credentials for Log in : ");


            // storing the current user in the Main Program itself (assumption)
            string currentUser;

            while (true)
            {
                Console.WriteLine("Please Enter the Credentials for Log in : ");

                //getting user details
                Console.WriteLine("Enter UserName : ");
                string userInputUserName = Console.ReadLine();
                Console.WriteLine("Enter Password : ");
                string userInputPassword = Console.ReadLine();

                // checking the validity

                bool isValid = AuthServiceObj.ValidateUser(userInputUserName, userInputPassword);
                if (isValid)
                {
                    currentUser = userInputUserName;
                    break;
                }
                else if (AuthServiceObj.IsAccountBlocked())
                {
                    Console.WriteLine("Too many failed login attempts.");
                    Console.WriteLine("Your account has been blocked.");
                    Thread.Sleep(2000);
                    // closing the program because of failed attempts
                    return;

                }
            }

            // creating object reference for EmployeeServices

            EmployeeService empserv = new EmployeeService();
            SortingService empSorting = new SortingService(empserv);



            bool isExit = false;
            //Displaying the Menu
            while (!isExit)
            {
                Console.WriteLine(
    "\n1. Add Employee\n" +
    "2. View Employee\n" +
    "3. Sort Employee\n" +
    "4. Find the Nth Highest Salary\n" +
    "5. Find Duplicate Names\n" +
    "6. Reverse Employee Names\n" +
    "7. Calculate Bonus\n" +
    "8. Exit"
);
                

                Console.WriteLine("\n Select From the Menu : ");

                // we could have used convert.ToInt32 to get input but it would crash if input is STRING
                //int choice = Convert.ToInt32(Console.ReadLine());

                // int choice;  I inlined this in below code

                if (!int.TryParse(Console.ReadLine(),out int choice))
                {
                    Console.WriteLine("\n Invalid Input. Enter the number");
                    continue;
                }

                

                // implementing SWITCH case of Menu
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"choose type of employeee : \n" +
                            $"1. PartTimeEmployee\n" +
                            $"2. FullTimeEmployee ");
                        int chooseType = Convert.ToInt32(Console.ReadLine());

                        //CAN BE DONE THIS WAY 
                        //int empid = Convert.ToInt32(Console.ReadLine());
                        //string empName = Console.ReadLine();
                        //double empSalary = Convert.ToDouble(Console.ReadLine());

                        // BUT YOU CAN DIRECTLY TAKE INPUT DURING OBJECT CREATION ALSO AS BELOW
                        Console.WriteLine("\n enter the EmployeeId, Employee Name, Employee Salary");
                        if (chooseType == 1)
                        {
                            empserv.AddEmployee(new PartTimeEmployee(Convert.ToInt32(Console.ReadLine()),
                                                                    Console.ReadLine(),
                                                                    Convert.ToDouble(Console.ReadLine())));
                        }
                        else
                        {
                            empserv.AddEmployee(new FullTimeEmployee(Convert.ToInt32(Console.ReadLine()),
                                                                    Console.ReadLine(),
                                                                    Convert.ToDouble(Console.ReadLine())));
                        }
                        break;

                    case 2:
                        // view employee without bonuses
                        empserv.ViewEmployees();
                        break;

                    case 3:
                        // sort employees ON BASIS OF SALARY

                       Console.WriteLine($"choose type of employeee : \n" +
                           $"1. Used in build method\n" +
                           $"2. Bubble sort \n" +
                           $"3. Selection sort \n" +
                           $"4. Quick sort \n");
                        int chooseSortType = Convert.ToInt32(Console.ReadLine());
                        switch (chooseSortType)
                        {
                            case 1:
                                empSorting.BuiltInSorting();
                                break;
                            case 2:
                                empSorting.BubbleSorting();
                                break;
                            case 3:
                                empSorting.SelectionSorting();
                                break;
                            case 4:
                                empSorting.QuickSorting();
                                break;
                            default:
                                Console.WriteLine("invalid input");
                                break;

                        }
                        break;

                     

                        
                    case 4:
                        // Find Nth Highest Salary
                        int NthHighest = Convert.ToInt32(Console.ReadLine());
                        
                        double salaryMax=empSorting.NthHighestDistinct(NthHighest, out bool nVerification);
                        if (nVerification)
                        {

                            Console.WriteLine($"{NthHighest}th highest salary is {salaryMax}");
                        }
                        else
                        {

                            Console.WriteLine("Invalid N value");
                        }
                        break;

                
            


                    case 5:
                        // Find Duplicate Names
                        
                        List<string> duplicateNames = empserv.FindDuplicateNames();
                        if (duplicateNames.Count == 0)
                        {
                            Console.WriteLine("there are no duplicates found");
                        }
                        else
                        {
                            Console.WriteLine("Duplicate names are : ");
                            foreach(string name in duplicateNames)
                            {
                                Console.WriteLine(name);
                            }

                        }

                        break;
                    case 6:
                        // Reverse Employee Names
                        empserv.ViewEmployeesWithReveredEmployeeNames();
                        break;


                    case 7:
                        // Calculate Bonus and Display Employees along with Bonus
                        empserv.ViewEmployeesWithBonusCalculated();
                        break;


                    case 8:
                        // Exit
                        isExit = true;
                        break;

                }

            }

            
        }
    }
}

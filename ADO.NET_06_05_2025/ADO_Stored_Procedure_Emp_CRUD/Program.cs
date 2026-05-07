using ADO_Stored_Procedure_Emp_CRUD.Data;
using ADO_Stored_Procedure_Emp_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Stored_Procedure_Emp_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            EmployeeRespository repo = new EmployeeRespository();

            while (true)
            {
                Console.WriteLine("\n1. Display All Employees");
                Console.WriteLine("2. Display Employee By Id");
                Console.WriteLine("3. Add Employee");
                Console.WriteLine("4. Update Salary");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");

                Console.Write("\nEnter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        var list = repo.GetAllEmployees();
                        foreach (var e in list)
                        {
                            Console.WriteLine($"{e.Id} | {e.Name} | {e.Salary} | {e.DeptName}");
                        }
                        break;

                    case 2:
                        Console.Write("Enter Id: ");
                        int id = int.Parse(Console.ReadLine());

                        var emp = repo.GetEmployeeById(id);
                        if (emp == null)
                            Console.WriteLine("Employee not found");
                        else
                            Console.WriteLine($"{emp.Id} | {emp.Name} | {emp.Salary} | {emp.DeptName}");
                        break;

                    case 3:
                        Employee newEmp = new Employee();

                        Console.Write("Name: ");
                        newEmp.Name = Console.ReadLine();

                        Console.Write("Salary: ");
                        newEmp.Salary = decimal.Parse(Console.ReadLine());

                        Console.Write("Dept: ");
                        newEmp.DeptName = Console.ReadLine();

                        repo.AddEmployee(newEmp);
                        Console.WriteLine("Employee added");
                        break;

                    case 4:
                        Console.Write("Enter Id: ");
                        int uid = int.Parse(Console.ReadLine());

                        Console.Write("Enter New Salary: ");
                        decimal sal = decimal.Parse(Console.ReadLine());

                        repo.UpdateSalary(uid, sal);
                        Console.WriteLine("Salary updated");
                        break;

                    case 5:
                        Console.Write("Enter Id: ");
                        int did = int.Parse(Console.ReadLine());

                        repo.DeleteEmployee(did);
                        Console.WriteLine("Employee deleted");
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }

}
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;
namespace DEMO02_crud
{
    internal class Program
    {
        // Method to add new roecord in DB
        

        static void Main(string[] args)
        {
            // establishig connection with SQL server
            SqlConnection cn = new SqlConnection(@"data source =  ACU-HYD-LT-1908\SQLEXPRESS;
                                                        initial catalog = DEMO02_crud ;
                                                        trusted_Connection=True ; 
                                                        TrustServerCertificate=True; 
                                                        ");
            CrudOperarions operations = new CrudOperarions();
            try
            { 
                cn.Open();
                Console.WriteLine("connection successful ....");

               

                // Main user Menu
            backToMainMenu:
                Console.WriteLine("-----------------------------------------");

                Console.WriteLine($"1. Insert New student\n" +
                    $"2. Update student Course\n" +
                    $"3. Delete Student\n" +
                    $"4. View Student\n" +
                    $"5. Exit ");
                int choice = Convert.ToInt32(Console.ReadLine());
             
                switch (choice)
                {
                    case 1:
                        string tname, tcourse;
                        // accepting the new data from user
                        Console.WriteLine("enter the name of the student");
                        tname = Console.ReadLine();
                        Console.WriteLine("enter the course of the student");
                        tcourse = Console.ReadLine();

                        // calling the InsertOperation Method
                        operations.StudentInsertOperation(cn, tname, tcourse);

                        goto backToMainMenu;
                    case 2:
                        

                        // accepting the new data from user
                        Console.WriteLine("enter the id of the student");
                        int tid = Convert.ToInt32( Console.ReadLine());
                        if (!operations.IsExist(cn, tid))
                        {
                            Console.WriteLine("id does not exists....");
                        }
                        else
                        {
                            Console.WriteLine("enter the new course of the student");
                            tcourse = Console.ReadLine();

                            // calling the StudentCourseUpdateOperation Method
                            operations.StudentCourseUpdateOperation(cn, tid, tcourse);
                            
                        }
                        goto backToMainMenu;

                    case 3:

                        // accepting the new data from user
                        Console.WriteLine("enter the id of the student");
                        tid = Convert.ToInt32(Console.ReadLine());
                        if (!operations.IsExist(cn,tid))
                        {
                            Console.WriteLine("id does not exists...");
                        }
                        else
                        {
                            operations.StudentDeleteOperation(cn, tid);
                        }
                        goto backToMainMenu;
                    case 4:

                        operations.StudentDisplayOperation(cn);
                        goto backToMainMenu;
                    case 5:
                        break;
                }
                
                
             

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                

            }
            finally
            {
                cn.Close();
            }
        }
    }
}

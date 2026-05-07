using System;
using System.Data.SqlClient;

namespace ADO_ExecuteScaler_05_05_2026_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection cn = new SqlConnection(
                @"Data Source=ACU-HYD-LT-1908\SQLEXPRESS;
                  Initial Catalog=db_executeScaler_05_06_2026;
                  Trusted_Connection=True;
                  TrustServerCertificate=True;"
            );

            try
            {
                cn.Open();
                Console.WriteLine("Connection established...");

                DisplayTotalSalary(cn);   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("closing first connection.....");
                cn.Close();

            }

            try
            {
                cn.Open();
                Console.WriteLine("Connection established again...");

                DisplayMaximumSalary(cn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("closing second connection.....");
                cn.Close();
            }
        }


        // method to display total salary
        static void DisplayTotalSalary(SqlConnection cn)
        {
            string query = "SELECT SUM(empSalary) FROM Employee";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                object result = cmd.ExecuteScalar();



                decimal totalSalary = result != DBNull.Value
                                      ? Convert.ToDecimal(result)
                                      : 0;

                Console.WriteLine($"Total salary sum is: {totalSalary}");
            }
        }




        /*Write a method to display maximum salary from
            salary column from Employees table*/

        static void DisplayMaximumSalary(SqlConnection cn)
        {
            string query = "SELECT MAX(empSalary) FROM Employee";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                object result = cmd.ExecuteScalar();



                decimal MaxSalary = result != DBNull.Value
                                      ? Convert.ToDecimal(result)
                                      : 0;

                Console.WriteLine($"Maximum salary  is: {MaxSalary}");
            }
        }
    }

}

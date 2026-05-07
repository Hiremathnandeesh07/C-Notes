using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ADO_User_Pass_Checking_using_ExecuteReader
{
    internal class Program
    {

        // Log in operation
        static void LogInOperation(SqlConnection cn)
        {
            Console.WriteLine("enter username : ");
            string tusername = Console.ReadLine();
            Console.WriteLine("enter password : ");
            string tpassword = Console.ReadLine();

            // creating sql query
            string query = "SELECT * FROM tableusers where username = @username and password = @password";

            // creating sql command
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@username", tusername);
            cmd.Parameters.AddWithValue("@password", tpassword);

            // running query
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    Console.WriteLine("welcome" + reader["firstname"]);
                }
            }
            else
            {
                Console.WriteLine("invalid credentials ......");
            }

            
        }

        static void Main(string[] args)
        {
            SqlConnection cn = new SqlConnection(
                                @"Data Source=ACU-HYD-LT-1908\SQLEXPRESS;
                                   Initial Catalog=db_usernamePassword_05_05_2026;
                                   Trusted_Connection=True;
                                   TrustServerCertificate=True;"
                                    );

            try
            {
                cn.Open();

                LogInOperation(cn);

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
        }


    }
}

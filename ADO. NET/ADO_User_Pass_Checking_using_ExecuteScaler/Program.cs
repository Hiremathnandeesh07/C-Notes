using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_UserName_Password_Checking
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // sql server connection
            SqlConnection cn = new SqlConnection(
                @"Data Source=ACU-HYD-LT-1908\SQLEXPRESS;
                  Initial Catalog=db_usernamePassword_05_05_2026;
                  Trusted_Connection=True;
                  TrustServerCertificate=True;"
            );

            try
            {

                // connection on
                cn.Open();
                Console.WriteLine("connection successfull....");

                string tusername = Console.ReadLine();
                string tpassword = Console.ReadLine();
                if (!CheckUsernamePassword(cn, tusername, tpassword))
                {
                    Console.WriteLine("invalid credentials...");
                }
                else
                {
                    Console.WriteLine("right credentials...... good");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                throw;
            }
            finally
            {

            }
        }
        static bool CheckUsernamePassword(SqlConnection cn, string tusername,string tpassword)
        {

            // creating query
            string query = "SELECT COUNT(*) FROM TableUsers WHERE UserName = @username AND Password = @password";

            // creating command
            SqlCommand cmd = new SqlCommand(query, cn);

            cmd.Parameters.AddWithValue("@username", tusername);
            cmd.Parameters.AddWithValue("@password", tpassword);

            // running query
            int result =Convert.ToInt32( cmd.ExecuteScalar());
            return result > 0;
            
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ADO_Stored_Procedure_CRUD_operations
{
    internal class Program
    {
        // method to handle adding od new student
        public static void AddStudent(SqlConnection cn,string tname,string tcourse)
        {

            cn.Open();
            // as i have not sql query here i will be using
            // stored procedure so below is how it is  implimented
            SqlCommand cmd = new SqlCommand("sp_AddStudent", cn);

            //specifying that the command type is stored procedure 
            cmd.CommandType = CommandType.StoredProcedure;

            // adding the values
            cmd.Parameters.AddWithValue("@Name", tname);
            cmd.Parameters.AddWithValue("@Course", tcourse);


            //running
            object result = cmd.ExecuteScalar();

            int newId = Convert.ToInt32(result);
            Console.WriteLine($"welcome {tname} your id is : {newId}");

            cn.Close();

        }

        static void Main(string[] args)
        {
            SqlConnection cn = new SqlConnection(
                                                @"Data Source=ACU-HYD-LT-1908\SQLEXPRESS;
                                                   Initial Catalog=ADO_Stored_Procedure_CRUD_operations;
                                                   Trusted_Connection=True;
                                                   TrustServerCertificate=True;"
                                                );


            try
            {
                Console.WriteLine("enter the student name");
                string tname = Console.ReadLine();
                Console.WriteLine("enter the course name");
                string tcourse = Console.ReadLine();
                AddStudent(cn, tname, tcourse);
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
           

        }
    }
}

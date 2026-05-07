using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ADO_DataReaderDEMO1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // connecting to sql server
           

            try
            {
                SqlConnection cn = new SqlConnection(
                   @"Data Source=ACU-HYD-LT-1908\SQLEXPRESS;
                   Initial Catalog=db_executeScaler_05_06_2026;
                   Trusted_Connection=True;
                   TrustServerCertificate=True;"
               );

                cn.Open();
                Console.WriteLine("connected to sql....");


                //DISPLAYING THE RECORD PARTICULARLY BASED ON STUDENTID
                int tid = Convert.ToInt32(Console.ReadLine());
                string query = "SELECT * FROM student WHERE Studentid = " + tid;
                SqlCommand cmd = new SqlCommand(query, cn);

                // creating data reader object
                SqlDataReader reader =  cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("student found with this id..");
                    if (reader.Read() == true)
                    {
                        Console.WriteLine("student name with this id is " + reader["studentName"]);
                    }
                }
                else
                {
                    Console.WriteLine("student not found");
                }

                reader.Close();
                cn.Close();




                // DISPLAYING THE STUDENT ALL DATA
                cn.Open();

                query = "SELECT * FROM student ";
                cmd = new SqlCommand(query, cn);

                // creating data reader object
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"student name is : {reader["studentName"]} ");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }


        }
    }
}

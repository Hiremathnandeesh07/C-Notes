using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//
using System.Data;
using System.Data.SqlClient;


namespace C__05_05_2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // establishig connection with SQL server

                try
            {
                SqlConnection cn = new SqlConnection(@"data source =  ACU-HYD-LT-1908\SQLEXPRESS;
                                                        initial catalog = DemoDB ;
                                                        trusted_Connection=True ; 
                                                        TrustServerCertificate=True; 
                                                        ");
                cn.Open();
                Console.WriteLine("connection successful ....");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
                
            }
        }
    }
}

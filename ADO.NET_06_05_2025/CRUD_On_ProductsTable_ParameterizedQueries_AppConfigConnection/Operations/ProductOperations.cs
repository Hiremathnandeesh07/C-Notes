using CRUD_On_ProductsTable_ParameterizedQueries.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_On_ProductsTable_ParameterizedQueries.Operations
{
     public class ProductOperations
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        // SqlConnection cn = new SqlConnection(
        //                @"Data Source=ACU-HYD-LT-1908\SQLEXPRESS;
        //           Initial Catalog=db_usernamePassword_05_05_2026;
        //           Trusted_Connection=True;
        //           TrustServerCertificate=True;"
        //);

        //added in app.config



        // adding the product
        public static void AddProduct(TableProducts tp)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {

                try
                {
                    cn.Open();
                    // generating query
                    string query = "insert into TableProducts (name,category,price) values (@name, @category, @price)";

                    // creating command
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", tp.Name);
                    cmd.Parameters.AddWithValue("@category", tp.Category);
                    cmd.Parameters.AddWithValue("@price", tp.Price);

                    // running query
                    cmd.ExecuteNonQuery();

                }
                catch (Exception )
                {

                    throw;
                }
            }
          
        }


        //updating product price
        public static void UpdatePrice(string tname,int tprice)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    cn.Open();

                    string query = "update tableproducts set price = @tprice where name = @tname";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@tname", tname);
                    cmd.Parameters.AddWithValue("@tprice", tprice);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception )
                {

                    throw;
                }
            }


            
        }

        // diaplying the specific product based on it
        public static void DisplayProduct(int tid)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    cn.Open();

                    string query = "select * from tableproducts where id = @tid";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@tid", tid);
                    

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"product id : {reader["id"]}   name : {reader["name"]}");
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        // display all the products
        public static void DisplayAllProducts()
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    cn.Open();
                    string query = "select * from tableproducts";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"name : {reader["name"]}  category :{reader["category"]}  price : {reader["price"]}");
                    }

                }
                catch (Exception )
                {

                    throw;
                }
            }
        }


        // delete the product based on ID
        public static void DeleteProduct(int tid)
        {
            using(SqlConnection cn= new SqlConnection(connectionString))
            {
                try
                {
                    cn.Open();
                    string query = "delete from tableproducts where id=@tid";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", tid);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}

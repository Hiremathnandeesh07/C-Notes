using System;
using System.Collections.Generic;
using System.Data;

using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WEBAPI_CORE_CRUD_Nandeesh_WithDataBase_ProdctsTable.Models
{
    public class ProductData
    {
        private readonly string _connectionString;

        public ProductData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // get all data
        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();
           
            
                using (SqlConnection con = new SqlConnection(_connectionString))
                {


                    string query = "select * from products";

                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Product
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"])
                        });


                    }



                }
                return list;
            
            

          
        }

        // get by id 

        public Product? GetById(int id)
        {
            Product? product = null;

            using(SqlConnection con=new SqlConnection(_connectionString))
            {
                string query = "select * from products where id=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                   product=new Product{
                       Id = (int)reader["id"],
                       Name = reader["name"].ToString(),
                       Price = Convert.ToDecimal(reader["price"])
                   };
                }
            }
            return product;

            
        }

       
    }
}

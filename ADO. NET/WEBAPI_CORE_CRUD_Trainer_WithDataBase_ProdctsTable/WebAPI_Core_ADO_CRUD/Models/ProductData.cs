using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebAPI_Core_ADO_CRUD.Models
{
    public class ProductData
    {
        private readonly string _connectionString;

        public ProductData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // GET ALL
        public List<Product> GetAll()
        {
            var list = new List<Product>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", con);
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

        // GET BY ID
        public Product? GetById(int id)
        {
            Product? product = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    product = new Product
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Price = (decimal)reader["Price"]
                    };
                }
            }
            return product;
        }

        // INSERT
        public void Add(Product product)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Products(Name, Price) VALUES(@Name, @Price)", con);

                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // UPDATE
        public void Update(Product product)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Products SET Name=@Name, Price=@Price WHERE Id=@Id", con);

                cmd.Parameters.AddWithValue("@Id", product.Id);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Products WHERE Id=@Id", con);

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

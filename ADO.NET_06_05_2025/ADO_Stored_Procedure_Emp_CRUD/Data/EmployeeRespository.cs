using ADO_Stored_Procedure_Emp_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Stored_Procedure_Emp_CRUD.Data
{
    public class EmployeeRespository 
    {

        private readonly DataBaseHelper _db;

        public EmployeeRespository()
        {
            _db = new DataBaseHelper();
        }

        //  Get All
        public List<Employee> GetAllEmployees()
        {

            List<Employee> list = new List<Employee>();

            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Employee
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Salary = (decimal)reader["Salary"],
                            DeptName = reader["DeptName"].ToString()
                        });
                    }
                }

                return list;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // ✅ Get By Id
        public Employee GetEmployeeById(int id)
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_GetEmployeeById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Employee
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Salary = (decimal)reader["Salary"],
                            DeptName = reader["DeptName"].ToString()
                        };
                    }
                }

                return null;
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            }
            
        
       

        // ✅ Add
        public void AddEmployee(Employee emp)
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_AddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", emp.Name);
                    cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                    cmd.Parameters.AddWithValue("@DeptName", emp.DeptName);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // ✅ Update Salary
        public void UpdateSalary(int id, decimal salary)
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateSalary", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Salary", salary);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // ✅ Delete
        public void DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
  
    }
}


using MiniProject_BankTransaction_App.Data;
using MiniProject_BankTransaction_App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiniProject_BankTransaction_App.Repositories
{

    public class AdminRepository
    {
        private DatabaseHelper _db = new DatabaseHelper();

        // admin login
        public int AdminLogin(string userName, String password)
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_AdminLogin", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int result = (int)cmd.ExecuteScalar();
                    return result;


                }
            }
            catch(SqlException )
            {
                throw;
            }
        }

        // adding customer
        public int AddCustomer(
                            string name, string gender, string mobile, string email, string address,
                           string aadhaar, string accType,
                           string password
                             )
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_RegisterCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Passing parameters to stored procedure

                    cmd.Parameters.AddWithValue("@FullName", name);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@MobileNumber", mobile);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@AadhaarNumber", aadhaar);
                    cmd.Parameters.AddWithValue("@AccountType", accType);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }


        // updating customer
        public int UpdateCustomer(string accountNumber, string mobileNumber, string email, string address, string accType)
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateCustomer", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);

                    cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@AccountType", accType);
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result;

                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        // deleting customer 
        public int DeleteCustomer(string accountNumber)
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_DeleteCustomer", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);


                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result;

                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        // view all customers
        public List<Customer> ViewAllCustomers()
        {
            List<Customer> users = new List<Customer>();
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_ViewAllCustomers", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Customer customer = new Customer()
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            FullName = reader["FullName"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            MobileNumber = reader["MobileNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            Address = reader["Address"].ToString(),
                            AadhaarNumber = reader["AadhaarNumber"].ToString(),
                            AccountType = reader["AccountType"].ToString(),
                            AccountNumber = Convert.ToInt64(reader["AccountNumber"]),
                            Password = reader["Password"].ToString(),
                            Balance = Convert.ToDecimal(reader["Balance"]),
                            AccountStatus = reader["AccountStatus"].ToString(),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                        };

                        users.Add(customer);
                    }
                    reader.Close();
                    return users;

                }
            }
            catch (SqlException)
            {
                throw;
            }
        }


        // search customer
        public Customer SearchCustomer(string accNo)
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {

                    SqlCommand cmd = new SqlCommand("sp_SearchCustomerByMbNo", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountNumber", accNo);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Customer customer = new Customer();
                        while (reader.Read())
                        {

                            customer.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                            customer.FullName = reader["FullName"].ToString();
                            customer.Gender = reader["Gender"].ToString();
                            customer.MobileNumber = reader["MobileNumber"].ToString();
                            customer.Email = reader["Email"].ToString();
                            customer.Address = reader["Address"].ToString();
                            customer.AadhaarNumber = reader["AadhaarNumber"].ToString();
                            customer.AccountType = reader["AccountType"].ToString();
                            customer.AccountNumber = Convert.ToInt64(reader["AccountNumber"]);
                            customer.Password = reader["Password"].ToString();
                            customer.Balance = Convert.ToDecimal(reader["Balance"]);
                            customer.AccountStatus = reader["AccountStatus"].ToString();
                            customer.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);



                        }
                        return customer;
                    }


                    else return null;
                }
            }
            catch (SqlException)
            {
                throw;
            }

        }



        // view customer by type
        public List<Customer> GetCustomersByAccountType(string accType)
        {
            List<Customer> users = new List<Customer>();
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_ViewCustomerByType", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountType", accType);
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer customer = new Customer()
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            FullName = reader["FullName"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            MobileNumber = reader["MobileNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            Address = reader["Address"].ToString(),
                            AadhaarNumber = reader["AadhaarNumber"].ToString(),
                            AccountType = reader["AccountType"].ToString(),
                            AccountNumber = Convert.ToInt64(reader["AccountNumber"]),
                            Password = reader["Password"].ToString(),
                            Balance = Convert.ToDecimal(reader["Balance"]),
                            AccountStatus = reader["AccountStatus"].ToString(),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                        };

                        users.Add(customer);
                    }
                    reader.Close();
                    return users;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        // get all transactions  by acc no
        public List<Transaction> ViewTransactionsOnAccNo(string accNo)
        {
            List<Transaction> acctransactions = new List<Transaction>();
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_ViewTransactionHistory", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountNumber", accNo);
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Transaction transaction = new Transaction()
                            {
                                TransactionId = Convert.ToInt32(reader["TransactionId"]),

                                AccountNumber = Convert.ToInt64(reader["AccountNumber"]),

                                TransactionType = reader["TransactionType"].ToString(),

                                Amount = Convert.ToDecimal(reader["Amount"]),

                                TransactionDate = Convert.ToDateTime(reader["TransactionDate"]),

                                BalanceAfterTransaction = Convert.ToDecimal(reader["BalanceAfterTransaction"])
                            };
                            acctransactions.Add(transaction);

                        }
                        return acctransactions;
                    }
                    else return null;

                }
            }
            catch (Exception)
            {
                throw;
            }

            
        }


        // freeze customer account 
        public int FreezeAccount(string accountNumber)
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_FreezeAccount", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);


                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}

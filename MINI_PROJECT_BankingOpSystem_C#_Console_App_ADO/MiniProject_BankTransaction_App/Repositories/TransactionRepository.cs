using MiniProject_BankTransaction_App.Data;
using MiniProject_BankTransaction_App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_BankTransaction_App.Repositories
{
    internal class TransactionRepository
    {
        private readonly DatabaseHelper _db = new DatabaseHelper();


        // customer login
        public string CustomerLogin(string accNo, string password)
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_CustomerLogin", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountNumber", accNo);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        string cusName = "";

                        while (reader.Read())
                        {
                            cusName = reader["FullName"].ToString();
                        }

                        return cusName;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }


        // deposit amount
        internal int DepositAmount(string accNo, decimal amount)
        {

            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_DepositAmount", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountNumber", accNo);
                    cmd.Parameters.AddWithValue("@Amount", amount);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return 1;
                }
            }
            catch (SqlException e)
            {
                throw;
            }
        }

        // get the balance 
        public Int64  GetBalance(string accNo)
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_CheckBalance", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountNumber", accNo);
                    con.Open();

                    var result = Convert.ToInt64(cmd.ExecuteScalar());
                    return result;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }


        // withdraw ammount
        public int WithdrwDrawAmount(string accNo, long amount)
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_WithDrawAmount", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountNumber", accNo);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return 1;

                }
            }
            catch (SqlException)
            {
                throw;
            }
        }


        // show mini statement 
        public List<Transaction> ShowMiniStatement(string accNo)
        {
            List<Transaction> transactions = new List<Transaction>();

            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_ShowMiniStatement", con);

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

                                BalanceAfterTransaction =
                                    Convert.ToDecimal(reader["BalanceAfterTransaction"])
                            };

                            transactions.Add(transaction);
                        }

                        reader.Close();

                        return transactions;
                    }
                    else
                    {
                        return null;
                    }
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


        // changing password 
         public int ChangePassword(string accNo,string newPass)
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_ChangePassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountNumber", accNo);
                    cmd.Parameters.AddWithValue("@Password", newPass);

                    int result = cmd.ExecuteNonQuery();
                    return result == 1 ? 1 : 0;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        // fund trnasfer 
        public int FundTransfer(string tAccNo,string recAccNo,long amount)
            
        {
            try
            {
                using (SqlConnection con = _db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_FundTransfer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FromAccountNumber", tAccNo);
                    cmd.Parameters.AddWithValue("@ToAccountNumber", recAccNo);
                    cmd.Parameters.AddWithValue("@Amount", amount);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return 1;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

    }
}

using MiniProject_BankTransaction_App.Data;
using MiniProject_BankTransaction_App.Repositories;
using MiniProject_BankTransaction_App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_BankTransaction_App.Services
{
    public class AdminService
    {
        private readonly AdminRepository _repoAdmin = new AdminRepository();

        // admin login
        public bool AdminLogin(string userName, String password)
        {
            try
            {
                if (_repoAdmin.AdminLogin(userName, password) > 0)
                {
                    Console.WriteLine("log in successfull...");
                    return true;
                }
                else
                {
                    Console.WriteLine("invalid credentials....");
                    return false;
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // adding customer
        public void AddCustomer(string name, string gender, string mobile, string email, string address,
                           string aadhaar, string accType,
                           string password)
        {
            try
            {
                if (_repoAdmin.AddCustomer(name, gender, mobile, email, address, aadhaar, accType, password) == 1)
                {
                    Console.WriteLine("addedd new customer....");

                }
                else
                {
                    Console.WriteLine("issue during adding....");
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // updating customer
        public void UpdateCustomer(string accountNumber,string mobileNumber, string email,string address, string accType)
        {
            try
            {
                if (_repoAdmin.UpdateCustomer(accountNumber, mobileNumber, email, address, accType) == 1)
                {
                    Console.WriteLine("updated succesfully...");
                }
                else
                {
                    Console.WriteLine("error during update...");
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        // delete customer
        public void DeleteCustomer(string accountNumber)
        {
            try
            {
                if (_repoAdmin.DeleteCustomer(accountNumber) == 1)
                {
                    Console.WriteLine("updated succesfully...");
                }
                else
                {
                    Console.WriteLine("error during update...");
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // view all customers
        public void ViewAllCustomers()
        {
            List<Customer> users = _repoAdmin.ViewAllCustomers();

            Console.WriteLine();

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(
                $"{"ID",-5} {"Name",-20} {"Gender",-10} {"Mobile",-15} {"Email",-25} {"Account Type",-15} {"Account Number",-18} {"Balance",-12} {"Status",-10}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (Customer customer in users)
            {
                Console.WriteLine(
                    $"{customer.CustomerId,-5} " +
                    $"{customer.FullName,-20} " +
                    $"{customer.Gender,-10} " +
                    $"{customer.MobileNumber,-15} " +
                    $"{customer.Email,-25} " +
                    $"{customer.AccountType,-15} " +
                    $"{customer.AccountNumber,-18} " +
                    $"{customer.Balance,-12} " +
                    $"{customer.AccountStatus,-10}");
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        // search customer
        public void SearchCustomer(string accNo)
        {
            try
            {
                Customer user = _repoAdmin.SearchCustomer(accNo);

                if (user != null)
                {
                    Console.WriteLine();

                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(
                        $"{"ID",-5} {"Name",-20} {"Gender",-10} {"Mobile",-15} {"Email",-25} {"Account Type",-15} {"Account Number",-18} {"Balance",-12} {"Status",-10}");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");

                    Console.WriteLine(
                        $"{user.CustomerId,-5} " +
                        $"{user.FullName,-20} " +
                        $"{user.Gender,-10} " +
                        $"{user.MobileNumber,-15} " +
                        $"{user.Email,-25} " +
                        $"{user.AccountType,-15} " +
                        $"{user.AccountNumber,-18} " +
                        $"{user.Balance,-12} " +
                        $"{user.AccountStatus,-10}");

                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        // get customers based on account type
        // view all customers
        public void GetCustomersByAccountType(string accType)
        {
            List<Customer> users = _repoAdmin.GetCustomersByAccountType(accType);

            Console.WriteLine();

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(
                $"{"ID",-5} {"Name",-20} {"Gender",-10} {"Mobile",-15} {"Email",-25} {"Account Type",-15} {"Account Number",-18} {"Balance",-12} {"Status",-10}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");

            try
            {
                foreach (Customer customer in users)
                {
                    Console.WriteLine(
                        $"{customer.CustomerId,-5} " +
                        $"{customer.FullName,-20} " +
                        $"{customer.Gender,-10} " +
                        $"{customer.MobileNumber,-15} " +
                        $"{customer.Email,-25} " +
                        $"{customer.AccountType,-15} " +
                        $"{customer.AccountNumber,-18} " +
                        $"{customer.Balance,-12} " +
                        $"{customer.AccountStatus,-10}");
                }

                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        // get customers transaction hitory by accNo
        public void ViewTransactionsOnAccNo(string accNo)
        {
            List<Transaction> users = _repoAdmin.ViewTransactionsOnAccNo(accNo);

            Console.WriteLine();

            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(
                $"{"Txn ID",-10} {"Account No",-18} {"Type",-15} {"Amount",-12} {"Txn Date",-25} {"Balance After",-15}");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");

            foreach (Transaction transaction in users)
            {
                Console.WriteLine(
                    $"{transaction.TransactionId,-10} " +
                    $"{transaction.AccountNumber,-18} " +
                    $"{transaction.TransactionType,-15} " +
                    $"{transaction.Amount,-12} " +
                    $"{transaction.TransactionDate,-25} " +
                    $"{transaction.BalanceAfterTransaction,-15}");
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
        }

        // freeze customer account 
        public void FreezeAccount(string accountNumber)
        {
            try
            {
                if (_repoAdmin.FreezeAccount(accountNumber) == 1)
                {
                    Console.WriteLine("Freezed succesfully...");
                }
                else
                {
                    Console.WriteLine("error during update...");
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

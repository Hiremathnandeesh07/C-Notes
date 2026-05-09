using MiniProject_BankTransaction_App.Models;
using MiniProject_BankTransaction_App.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_BankTransaction_App.Services
{
    public class CustomerService
    {
        private readonly TransactionRepository _transRepo = new TransactionRepository();

        // customer login service
        public string CustomerLogin(string accNo, string password, out bool CustomerLogin)
        {
            CustomerLogin = true;
            return _transRepo.CustomerLogin(accNo, password);
        }

        // deposite amount
        public void DepositAmount(string accNo, decimal amount)
        {
            // checking the amount validity
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount...");
                return;
            }

            // calling the repo method
            if (_transRepo.DepositAmount(accNo, amount) == 1)
            {
                Console.WriteLine("transaction successfull....");
            }
            else
            {
                Console.WriteLine("transaction error.....");
            }
        }

        // withdraw amount
        public void WithDrawAmount(string accNo, Int64 amount)
        {
            if (amount > _transRepo.GetBalance(accNo))
            {
                Console.WriteLine("entered amount is more than the balance...");
                return;
            }
            else if (_transRepo.WithdrwDrawAmount(accNo, amount) == 1)
            {
                Console.WriteLine("withdrawal successfull...");
            }
            else
            {
                Console.WriteLine("error during withdrawal....");
            }
        }

        // get balance
        public void GetBalance(string accNo)
        {
            Console.WriteLine("Balance is :" + _transRepo.GetBalance(accNo));
        }



        // show mini statement
        public void ShowMiniStatement(string accNo)
        {
            List<Transaction> users = _transRepo.ShowMiniStatement(accNo);


            if (users != null)
            {
                Console.WriteLine();

                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(
                    $"{"Txn ID",-10} {"Account No",-18} {"Type",-15} {"Amount",-12} {"Txn Date",-25} {"Balance",-15}");
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
            else
            {
                Console.WriteLine("data do not exist...");
                return;
            }
        }


        // updating customer
        public void UpdateCustomer(string accountNumber, string mobileNumber, string email, string address, string accType)
        {
            try
            {
                if (_transRepo.UpdateCustomer(accountNumber, mobileNumber, email, address, accType) == 1)
                {
                    Console.WriteLine("updated succesfully...");
                }
                else
                {
                    Console.WriteLine("error during update...");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // change password
        public void ChangePassword(string accountNumber, string newPassword)
        {
            try
            {
                if (_transRepo.ChangePassword(accountNumber, newPassword) == 1)
                {
                    Console.WriteLine("Password changed Successfully...");
                }
                else
                {
                    Console.WriteLine("error during password updation...");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // fund trnasfer
        public void FundTransfer(string tAccNo, string recAccNo, long amount)
        {
            try
            {
                if (_transRepo.FundTransfer(tAccNo, recAccNo, amount) == 1)
                {
                    Console.WriteLine("transfer successfull...");
                }
                else
                {
                    Console.WriteLine("error during transfer.....");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}

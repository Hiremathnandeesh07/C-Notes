using BankingManagementSystem.Account;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagementSystem.Accounts

{
    public class Account: IAccount
    {
        public int AccountNumber { get; set; }
        public decimal Balance  { get; set; }

        public List<Transactions.Transaction> Transactions { get; set; } = new List<Transactions.Transaction>();

        public Account(int accNo, decimal balance)
        {
            AccountNumber = accNo;
            Balance = balance;
            Transactions.Add(new Transactions.Transaction(AccountNumber, "Opening", balance));

        }

        public virtual void Deposit(decimal amount) {
            Balance += amount;
            Transactions.Add(new Transactions.Transaction(AccountNumber, "Deposit", amount));
            Console.WriteLine("Amount Deposited : " + amount);
            ShowBalance();
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Transactions.Add(new Transactions.Transaction(AccountNumber, "Withdraw", amount));
                Console.WriteLine("Withdrawl Amount : " + amount);
                ShowBalance();


            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Balance: {Balance}");
        }
    } 
}

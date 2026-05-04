using BankingManagementSystem.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagementSystem.Account
{
    public interface IAccount
    {
        int AccountNumber { get; set; }
        decimal Balance { get; set; }

        List<Transaction> Transactions { get; }
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        void ShowBalance();

    }
}

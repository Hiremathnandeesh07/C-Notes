using BankingManagementSystem.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagementSystem.Account
{
    public class SavingAccount: Accounts.Account
    {
        public decimal InterestRate { get; set; }

        public SavingAccount(int accNo, decimal balance, decimal rate) : base(accNo, balance)
        {
            InterestRate = rate;
        }

        public void AddInterest()
        {
            Balance += Balance * InterestRate / 100;
        }

    }
}

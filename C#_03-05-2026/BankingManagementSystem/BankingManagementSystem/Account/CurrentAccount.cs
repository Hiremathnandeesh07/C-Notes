using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagementSystem.Account
{
    public class CurrentAccount: Accounts.Account
    {
        public decimal OverdraftLimit { get; set; } 
        public CurrentAccount(int accNo, decimal balance, decimal limit) : base (accNo, balance)
        {
            OverdraftLimit = limit;
        }

        public override void Withdraw(decimal amount)
        {
            if(amount <= Balance + OverdraftLimit)
            {
                base.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Overdraft limit exceeded");
            }
        }


    }


}

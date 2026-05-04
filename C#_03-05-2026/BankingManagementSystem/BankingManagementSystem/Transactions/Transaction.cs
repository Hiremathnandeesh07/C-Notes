using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagementSystem.Transactions
{
    using System;

    public class Transaction
    {
        public int AccountNumber { get; set; }
        public string Type { get; set; }   // Deposit / Withdraw
        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public Transaction(int accountNumber, string type, decimal amount)
        {
            AccountNumber = accountNumber;
            Type = type;
            Amount = amount;
            Date = DateTime.Now;
        }
    }
}

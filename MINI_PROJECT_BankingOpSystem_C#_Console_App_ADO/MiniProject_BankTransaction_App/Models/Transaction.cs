using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_BankTransaction_App.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public long AccountNumber { get; set; }

        public string TransactionType { get; set; }  // withdraw, deposite, transfer

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal BalanceAfterTransaction { get; set; }
    }
}

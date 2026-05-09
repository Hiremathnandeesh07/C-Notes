using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_BankTransaction_App.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string AadhaarNumber { get; set; }

        public string AccountType { get; set; }

        public long AccountNumber { get; set; }

        public string Password { get; set; }

        public decimal Balance { get; set; }

        public string AccountStatus { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

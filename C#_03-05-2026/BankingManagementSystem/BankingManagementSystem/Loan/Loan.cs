using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagementSystem.Loan
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int CustomerId { get; set; }
        public decimal LoanAmount { get; set; }
        public double  InterestRate { get; set; }   
        

        public Loan(int loanId, int custId, decimal amount, double rate)
        {
            LoanId = loanId;
            CustomerId = custId;
            LoanAmount = amount;
            InterestRate = rate;
        }

        public double CalculateInterest()
        {
            return (double)LoanAmount * InterestRate / 100;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"{LoanId} - {CustomerId} - {LoanAmount} - {InterestRate}");
        }
    }
}

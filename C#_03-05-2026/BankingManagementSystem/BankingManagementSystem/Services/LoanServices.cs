using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagementSystem.Services
{
    public class LoanServices
    {
        public static void ApplyForLoan() {

            Console.WriteLine("Enter the details to apply for the loan");
            Console.WriteLine("Enter the LoanId: ");
            int loanId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the CustomerID: ");
            int cusId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Loan Amount");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Rate");
            double rate = double.Parse(Console.ReadLine());

            Program.loans.Add(new Loan.Loan(loanId, cusId, amount, rate));
        }
        public static void LoanDetails() {
            Console.WriteLine("Enter the LoanId of the loan you want to get details");
            int loanId = Int32.Parse(Console.ReadLine());
            Loan.Loan curLoan = FindLoan(loanId);
            if (curLoan == null)
            {
                Console.WriteLine("No data found for Particular LoanID");
                return;
            }
            curLoan.ShowDetails();

        }

        public static void CalculateInterest() {
            Console.WriteLine("Enter the LoanId to get Interest");
            int loanId = Int32.Parse(Console.ReadLine());
            Loan.Loan curLoan = FindLoan(loanId);
            if(curLoan == null)
            {
                Console.WriteLine("No data found for Particular LoanID");
                return;
            }
            curLoan.CalculateInterest();
        }


        public static Loan.Loan FindLoan(int LoanId)
        {
            foreach(Loan.Loan curLoan in Program.loans)
            {
                if(curLoan.LoanId == LoanId)
                {
                    return curLoan;
                }
            }

            return null;
        }

    }
}

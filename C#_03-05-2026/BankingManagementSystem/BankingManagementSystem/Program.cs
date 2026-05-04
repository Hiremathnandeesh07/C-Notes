using BankingManagementSystem.Account;
using BankingManagementSystem.Loan;
using BankingManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace BankingManagementSystem
{
    internal class Program
    {


        public static List<IAccount> accounts = new List<IAccount>();

        public static List<Customers.Customer> customers = new List<Customers.Customer>();

        public static List<Loan.Loan> loans = new List<Loan.Loan>();

        

        static void Main(string[] args)
        {

            Console.WriteLine("Hi Welcome to Banking System : ) ");
            Console.WriteLine();


            while(true)
            {
                Console.WriteLine("Select the Operation You Want to do \n");
                
                Console.WriteLine("======= Banking System ========\n" +
                    "   1. Add Customer\n" +
                    "   2. View Customers\n" +
                    "   3. Create Account\n" +
                    "   4. Depost\n" +
                    "   5. Withdraw\n" +
                    "   6. Check Balance\n" +
                    "   7. Apply Loan\n" +
                    "   8. View Loans\n" +
                    "   9. View Transactions \n" +
                    "   10. Transfer Money\n" +
                    "   11. Exit\n" +
                    "==============================");
                int choice = Int32.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        CustomerServices.AddCustomer();
                        break;
                    case 2:
                        CustomerServices.ViewCustomer();
                        break;
                    case 3:
                        AccountServices.CreateAccount();
                        break;
                    case 4:
                        AccountServices.DepositMoney();
                        break;
                    case 5:
                        AccountServices.WithdrawMoney();
                        break;
                    case 6:
                        AccountServices.CheckBalance();
                        break;
                    case 7:
                        LoanServices.ApplyForLoan();
                        break;
                    case 8:
                        LoanServices.LoanDetails();
                        break;
                    case 9:
                        TransactionServices.ShowTransactions();
                        break;
                    case 10:
                        AccountServices.TransferMoney();
                        break;
                    case 11:
                        return;
                    default:
                        Console.WriteLine("Please enter a valid Service");
                        break;
                }
            }


        }
    }
}

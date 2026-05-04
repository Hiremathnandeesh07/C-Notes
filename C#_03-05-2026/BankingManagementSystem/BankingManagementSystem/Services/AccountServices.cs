using BankingManagementSystem.Account;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagementSystem.Services
{
    public class AccountServices
    {
        public static void CreateAccount()
        {
            Console.WriteLine("which type of account Account\n" +
                "1. Saving Account\n" +
                "2. Current Account");
            int option = Int32.Parse(Console.ReadLine().Trim());
            Console.WriteLine("Enter account Number");
            int acNo = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the balance");
            decimal bal = decimal.Parse(Console.ReadLine());

           
            switch(option)
            {
                case 1:
                    Console.WriteLine("Enter the interest Rate");
                    decimal interestRate = decimal.Parse(Console.ReadLine());
                    Program.accounts.Add(new SavingAccount(acNo, bal, interestRate));
                    break;

                case 2:
                    Console.WriteLine("Enter the interest Rate");
                    decimal overdraftLimit = decimal.Parse(Console.ReadLine());
                    Program.accounts.Add(new CurrentAccount(acNo, bal, overdraftLimit));
                    break;

                default:
                    Console.WriteLine("Enter the specific number please");
                    break;
            }
        }

        public static void DepositMoney()
        {
            Console.WriteLine("Enter the Account Number");
            int acNum = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Amount you want to Deposit");
            decimal amount = decimal.Parse(Console.ReadLine());
            IAccount reqAcc = SearchAccountNum(acNum);
            if (reqAcc == null)
            {
                Console.WriteLine("No Data for particular Account Number");
                return;
            }
            reqAcc.Deposit(amount);

        }

        public static void WithdrawMoney()
        {
            Console.WriteLine("Enter the Account Number");
            int acNum = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount you want to Withdraw");
            decimal amount = decimal.Parse(Console.ReadLine());
            IAccount reqAcc = SearchAccountNum(acNum);
            if(reqAcc == null)
            {
                Console.WriteLine("No Data for particular Account Number");
                return;
            }
            reqAcc.Withdraw(amount);
        }


        public static void CheckBalance()
        {
            Console.WriteLine("Enter the Account Number");
            int acNum = Int32.Parse(Console.ReadLine());
            IAccount reqAccount = SearchAccountNum(acNum);
            if (reqAccount == null)
            {
                Console.WriteLine("No Data for particular Account Number");
                return;
            }
            reqAccount.ShowBalance();
        }

        public static IAccount SearchAccountNum(int acNum)
        {
            foreach(IAccount reqaccount in Program.accounts)
            {
                if(reqaccount.AccountNumber == acNum)
                {
                    return reqaccount;
                }
            }
            return null;
        }


        public static void TransferMoney()
        {
            Console.WriteLine("Enter Sender Account Number");
            int fromAccNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Receiver Account Number");
            int toAccNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Amount");
            decimal amount = decimal.Parse(Console.ReadLine());

            IAccount fromAccount = SearchAccountNum(fromAccNo);
            IAccount toAccount = SearchAccountNum(toAccNo);

            if (fromAccount == null || toAccount == null)
            {
                Console.WriteLine("Invalid account number(s)");
                return;
            }

            
            fromAccount.Withdraw(amount);

            
            toAccount.Deposit(amount);

            Console.WriteLine("Transfer successful");
        }

    }
}

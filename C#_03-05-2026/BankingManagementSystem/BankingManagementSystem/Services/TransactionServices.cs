using BankingManagementSystem.Account;
using BankingManagementSystem.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagementSystem.Services
{
    public class TransactionServices
    {
        public static void ShowTransactions()
        {
            Console.WriteLine("Enter the Account Number to see its transactions");
            int acNum = Int32.Parse(Console.ReadLine());
            IAccount selectedAccount = AccountServices.SearchAccountNum(acNum);
            if(selectedAccount == null)
            {
                Console.WriteLine("No account found");
                return;
            }
            var trans = selectedAccount.Transactions;
            if(trans.Count == 0){
                Console.WriteLine("No transactions found");
                return;
            }

            foreach (var t in trans)
            {
                Console.WriteLine($"{t.Date} | {t.Type} | {t.Amount}");
            }
        }
    }
}

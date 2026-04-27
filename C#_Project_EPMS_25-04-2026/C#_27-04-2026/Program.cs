using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__27_04_2026
{
    class Bank
    {
        public Bank(string acNo, double balance)
        {
            AcNo = acNo;
            Balance = balance;
        }

        public string AcNo { set; get; }
        public double Balance { set; get; }
       


    }
    class NewBank : Bank
    {
        public NewBank(string acNo, double balance) : base(acNo, balance)
        {
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank b1 = new Bank("143",32131);
            b1.Balance = 45555;
            Console.WriteLine(b1.AcNo);
            
        }
    }
}

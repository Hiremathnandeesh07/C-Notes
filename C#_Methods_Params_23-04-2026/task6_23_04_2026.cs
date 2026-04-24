using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
    /*
     * accept restaurant bill amount into a method and return
     * 3% CGST and 5% SGST form method into main method
     * int main method you need to add those two and display the total
     * bill amount
     */
    internal class task6_23_04_2026
    {
        static void FindCgstSgst(int billAmount,out double totalCgst, out double totalSgst)
        {
            totalCgst = billAmount * 0.03;
            totalSgst = billAmount * 0.05;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter the restaurant bill amount : ");
            int billAmount = Convert.ToInt32(Console.ReadLine());
            double totalCgst, totalSgst;
            FindCgstSgst(billAmount, out totalCgst, out totalSgst);
            Console.WriteLine($"Total CGST is {totalCgst}");
            Console.WriteLine($"Total SGST is {totalSgst}");
            Console.WriteLine($"total bill amount is  {billAmount} + {totalCgst} + {totalSgst} = {billAmount+totalSgst+totalCgst}");
        }
    }
}

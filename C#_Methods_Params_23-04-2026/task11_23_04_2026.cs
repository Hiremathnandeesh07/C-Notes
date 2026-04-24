using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
   
    internal class task11_23_04_2026
    {

        // find the prime number in n numbers
        static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter the number : ");
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i = 2; i <= n; i++)
            {
                if (IsPrime(i) == true)
                {
                    Console.WriteLine(i + "\t");
                }
            }
        }
    }
}

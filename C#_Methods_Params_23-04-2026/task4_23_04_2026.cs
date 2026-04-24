using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
    /*
     * write mehtod to find prime ot not
     */
    internal class task4_23_04_2026
    {
        static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            for(int i = 2; i*i <= num ; i++)
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
            Console.WriteLine("enter the number to check whether it is PRIME or NOT");
            int num = Convert.ToInt32(Console.ReadLine());
            if (IsPrime(num))
            {
                Console.WriteLine("it is prime");
            }
            else
            {
                Console.WriteLine("not prime");
            }
        }
    }
}

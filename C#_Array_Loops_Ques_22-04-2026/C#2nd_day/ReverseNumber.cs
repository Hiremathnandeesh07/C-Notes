using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2nd_day
{
    internal class ReverseNumber
    {
        static void Main(string[] args)
        {
            //int num = 23456;
            //int rem = 0, newnum = 0;
            //while (num > 0) {
            //    rem = num % 10;
            //    newnum = newnum * 10 + rem;
            //    num = num / 10;
            //}
            //    Console.WriteLine(newnum);


            // NEW WAY
            int r = 0;
            Console.WriteLine("enter the number : ");
            int num = Convert.ToInt32(Console.ReadLine());
            while(num > 0)
            {
                r = num % 10;
                Console.Write(r);
                num = num / 10;
            }

        }
    }
}

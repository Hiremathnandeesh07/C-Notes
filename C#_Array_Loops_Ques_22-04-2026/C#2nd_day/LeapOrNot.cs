using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2nd_day
{
    internal class LeapOrNot
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the year");
            int year = Convert.ToInt32(Console.ReadLine());
            if((year%400==0) || (year%4==0 && year % 100 == 0))
            {
                Console.WriteLine("this is leap year");
            }
            else
            {
                Console.WriteLine("not leap year");
            }
        }
    }
}

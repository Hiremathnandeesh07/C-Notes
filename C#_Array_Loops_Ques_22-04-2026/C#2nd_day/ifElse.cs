using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2nd_day
{
    internal class ifElse
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the age of person");
            int age = int.Parse(Console.ReadLine());
            if(age > 18)
            {
                Console.WriteLine("you are eligible vote");
            }
            else
            {
                Console.WriteLine("not eligible to vote");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
    internal class paramParameter
    {
        static int AddMethod(params int[] numbers)
        {
            int sum = 0;
            foreach(int x in numbers)
            {
                sum += x;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("the result of 4 elements is " + AddMethod(3,4,5,6));
            Console.WriteLine("the result of 6 elements is " + AddMethod(3,4,34,21,5, 6));
            Console.WriteLine("the result of 2 elements is " + AddMethod(3,4));
        }
    }
    
}

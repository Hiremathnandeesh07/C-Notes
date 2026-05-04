using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
                List<int> numbers = new List<int>() { 3, 4, 5, 6, 12, 99, 23, 45, 1 };


                var result = numbers.All(n=>n>20);
            Console.WriteLine(result);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncRealTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 3, 4, 5, 6, 7, 8, 9 };
            Func<int, bool> isEven = n => n % 2 == 0;

            var result = numbers.Where(isEven);

            foreach(int x in result)
            {
                Console.WriteLine(x);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 3, 4, 5, 6, 7, 8, 9 };
            numbers.Add(345);
           
            foreach(int x in numbers)
            {
                Console.WriteLine(x);
            }
        }
    }
}

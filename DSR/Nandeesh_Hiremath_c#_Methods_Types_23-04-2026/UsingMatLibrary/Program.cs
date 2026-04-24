using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatLibrary;
namespace UsingMatLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MatLib ml = new MatLib();
            int a = 34, b = 12;
            Console.WriteLine("sum is : " + ml.Add(a,b));
            Console.WriteLine("subtract is : " + ml.Subtract(a,b));
            Console.WriteLine("Multiply is : " + ml.Multiply(a,b));
            Console.WriteLine("Divide is : " + ml.Divide(a,b));
        }
    }
}

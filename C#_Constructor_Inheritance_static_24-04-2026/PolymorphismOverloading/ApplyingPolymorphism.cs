using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismOverloading
{
    internal class ApplyingPolymorphism
    {
        //method with difeerent number of parameters
        public static void Sum(int a,int b)
        {
            Console.WriteLine($"Sum is {a+b}");
        }
        

        //method with three parameters a b and c
        public static void Sum(int a,int b,int c)
        {
            Console.WriteLine($"sum is {a+b+c}");
        }
    }
}

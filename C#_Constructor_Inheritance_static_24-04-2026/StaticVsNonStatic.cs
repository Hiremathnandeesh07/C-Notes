using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_4th_DAY
{
    internal class StaticVsNonStatic
    {
        int number = 2345;
        static int staticNumber=6789;

        static void Main(string[] args)
        {
        //Console.WriteLine(number); // cannot access number here because it is  non static
            Console.WriteLine(staticNumber);
        }
    }
}

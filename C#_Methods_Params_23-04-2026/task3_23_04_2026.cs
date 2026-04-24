using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
    /*
     * accept the radius into a method and return Area of circle
     */
   
    internal class task3_23_04_2026
    {
        const double PI = 3.14159;

        static double AreaOfCircle(int radius)
        {
            return PI * radius * radius;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the radius ");
            Console.WriteLine($"Area of circle is " + AreaOfCircle(Convert.ToInt32(Console.ReadLine())));
        }
    }
}

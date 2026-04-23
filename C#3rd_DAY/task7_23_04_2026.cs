using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
    /*
     * take input and find both sum and product using out parameter
     */
    internal class task7_23_04_2026
    {
        static void Calculate(int a,int b,out int sum,out int product)
        {
            sum = a + b;
            product = a * b;
        }
        static void Main(string[] args)
        {
            int a, b, sum, product;
            Console.WriteLine("enter a :");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            Calculate(a, b, out sum, out product);
            Console.WriteLine($"sum is {sum}");
            Console.WriteLine($"product is {product}");
        }
        
        
    }
}

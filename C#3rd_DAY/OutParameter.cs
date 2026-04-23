using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
    internal class OutParameter
    {
        static void sumProduct(int a,int b,out int sum,out int product)
        {
            sum = a + b;
            product = a * b;
        }

        static void Main(string[] args)
        {
            int sum, product;
            sumProduct(23, 12, out sum, out product);
            Console.WriteLine($"the sum is {sum}");
            Console.WriteLine($"the product is {product}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfNUmbersUsingAsync
{
    internal class Program
    {
        static async  Task Main(string[] args)
        {
            int a = 34, b = 23;
            Console.WriteLine("waiting for the SunAsync Method to return value..........");
            int result = await SumAsync(a, b);
            Console.WriteLine("the result is : " + result);
        }

        private static async Task<int> SumAsync(int a, int b)
        {
            await Task.Delay(3000);
            return await InnerSumAsync(a, b);
        }

        private static async Task<int> InnerSumAsync(int a,int b)
        {
            await Task.Delay(6000);
            Console.WriteLine("delayed 6 seconds");
            return a + b;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhenAllUse
{
    internal class Program
    {

        // define async methods
        static async Task<int> Method1()
        {
            await Task.Delay(2000);
            return 20;
        }

        static async Task<int> Method2()
        {
            await Task.Delay(2000);
            return 20;
        }

        static async Task<int> Method3()
        {
            await Task.Delay(2000);
            return 20;
        }


        static async Task Main(string[] args)
        {
            int[] sum = await Task.WhenAll(Method1(), Method2(), Method3());
            int total = sum[0] + sum[1] + sum[2];
            Console.WriteLine($"total is : {total} ");

        }

       
    }
}

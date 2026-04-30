using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitCode
{
    internal class Program
    {
        public static async Task<String> PerformOperationAsync()
        {
            await Task.Delay(3000);
            return "this is delayed task . it ran after 3000 milliseconds";
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("calling async operation....");

            string result = await PerformOperationAsync();

            Console.WriteLine(result);
            Console.WriteLine("async operation comepleted.......");

        }

       
    }
}

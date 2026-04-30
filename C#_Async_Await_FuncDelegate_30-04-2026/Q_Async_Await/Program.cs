using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Async_Await
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
             Task.Delay(3000); 
             Console.WriteLine("hello");
        }
    }
}

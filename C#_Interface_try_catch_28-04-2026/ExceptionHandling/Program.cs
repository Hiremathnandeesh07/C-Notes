using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
           
            try
            {
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                int c = a / b;
                Console.WriteLine("result is :" + c);
            }
            catch (Exception ex)
            {
                Console.WriteLine("please do no enter b as 0");
                Console.WriteLine(ex.Message);
                
            }
        }
    }
}

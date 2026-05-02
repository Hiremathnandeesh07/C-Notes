using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            try
            {
                a = Convert.ToInt32(Console.ReadLine());
                b = Convert.ToInt32(Console.ReadLine());
                if (b == 0)
                {
                    throw new DivideByZeroException();
                }
                Console.WriteLine(a/b);
            }

            catch (DivideByZeroException d)
            {
                Console.WriteLine(d.Message);
            }
            finally
            {
                Console.WriteLine("programm end");
            }
        }
    }
}

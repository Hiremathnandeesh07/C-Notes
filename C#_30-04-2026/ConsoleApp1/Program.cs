using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {



        static int Add(int x, int y)
        {
            return x + y;
        }

        static void Main()
        {
            /* Func<int, int, int> op = (int a,int b)=> a + b;
             int result = op(3, 4);
             Console.WriteLine(result); // 7*/


            //Func<int> Names = () => 34;

            //Console.WriteLine(Names());

            List<int> numbers = new List<int> { 3, 4, 5, 6, 7, 8 };

            Func<int, bool> isEven = (n) => n % 2==0;

            IEnumerable<int> result = numbers.Where(isEven);

            foreach(int x in result)
            {
                Console.WriteLine(x);
            }





        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
    internal class Program
    {
        // method with parameters 
        static int add(int num1,int num2)
        {
            return num1 + num2;
        }


        // non static method
        void Hello()
        {
            Console.WriteLine("hi hello");
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Hello();


            Console.WriteLine("SUM is " + add(3,5));

        }
    }
}

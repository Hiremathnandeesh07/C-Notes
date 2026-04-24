using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3rd_DAY
{
    internal class PassByValueReference
    {
        static void swap(int num1, int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
            Console.WriteLine("in swap a=" + (num1) + " b = " + (num2));
        }

        //swap with reference
        static void SwapWithReference(ref int num1, ref int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
            Console.WriteLine("in function reference in swap a=" + (num1) + " b = " + (num2));
        }

        static void Main(string[] args)
        {
            int num1 = 23, num2 = 67;
            Console.WriteLine($"before swap in main methos a = {num1} and b = {num2}");
            swap(num1, num2);
            Console.WriteLine($"after swap in main methos a = {num1} and b = {num2}");


            Console.WriteLine("after using reference method");
            Console.WriteLine($"before swap in main methos a = {num1} and b = {num2}");
            SwapWithReference(ref num1, ref num2);
            Console.WriteLine($"after swap in main methos a = {num1} and b = {num2}");


        }
    }
}

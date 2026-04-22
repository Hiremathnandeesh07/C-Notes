using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2nd_day
{
    internal class Arrays
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {2,45,76,22,78,99 };
            int len = arr.Length;
            foreach(int x in arr)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
            Console.WriteLine("sorted array : ");
            Array.Sort(arr);
            foreach(int x in arr)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
            Console.WriteLine("reversed array : ");
            Array.Reverse(arr);
            foreach(int x in arr)
            {
                Console.Write(x + " ");
            }
        }
    }
}

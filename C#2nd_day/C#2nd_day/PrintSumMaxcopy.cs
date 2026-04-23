using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2nd_day
{
    internal class PrintSumMaxcopy
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of array");
            int len = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[len];
            int sum = 0;
            int max = int.MinValue;

            for (int i = 0; i < len; i++)
            {
                Console.Write("enter the " + (i + 1) + "th element : ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
                sum += arr[i];
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            Console.WriteLine("sum of elemets in array : " + sum);
            Console.WriteLine("Max element in array : " + max);
            Console.Write("elements copied from original array are : ");
            for (int i = 0; i < len; i++)
            {
                Console.Write(arr[i] + "\t");
            }
        }
    }
}

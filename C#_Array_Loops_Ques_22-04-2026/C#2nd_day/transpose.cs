using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2nd_day
{
    internal class transpose
    {
        static void Main(string[] args)
        {
            //Accept n array elements and print sum of an array elements
            int rows = 0;
            int cols = 0;
            int sum = 0;
            long product = 1;
            Console.WriteLine("enter no of rows : ");
            rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter no of columns");
            cols = Convert.ToInt32(Console.ReadLine());
            int[,] arr = new int[rows, cols];
            int[,] newArr = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine("Enter number for " + i + "th row and " + j + "th column");
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                    newArr[j, i] = arr[i, j];

                }

            }

            // printing original matrix
            Console.WriteLine("Elements in Original Matrix are : ");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arr[i, j] + "\t");

                }
                Console.WriteLine();

            }

            // printing transpose matrix
            Console.WriteLine("Elements in Transposed Matrix are : ");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(newArr[i, j] + "\t");

                }
                Console.WriteLine();

            }
        }
    }
}
